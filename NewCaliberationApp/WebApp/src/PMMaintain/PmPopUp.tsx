import React from 'react';
import DatePicker from 'react-datepicker';
import "react-datepicker/dist/react-datepicker.css";
import { ScheduleModel } from '../Models/PmModels';
import { GetPmScheduleDataById, UpdatePmScheduleData } from '../Api/PMApi'; // Import API functions
import './PmPopUp.css'; // Add styles for the popup

interface MachinePopupProps {
  machineId: string;
  onClose: () => void;
}

const MachinePopup: React.FC<MachinePopupProps> = ({ machineId, onClose }) => {
  const [scheduleData, setScheduleData] = React.useState<ScheduleModel | null>(null);
  const [loading, setLoading] = React.useState<boolean>(true);
  const [error, setError] = React.useState<string | null>(null);
  const [isEditing, setIsEditing] = React.useState<boolean>(false);
  const [formData, setFormData] = React.useState<ScheduleModel | null>(null);

  React.useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await GetPmScheduleDataById(machineId);
        setScheduleData(response.data);
        setFormData(response.data);
      } catch (error: any) {
        setError('Failed to fetch schedule data: ' + (error.message || 'Unknown error'));
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [machineId]);

  const handleEditClick = () => {
    setIsEditing(!isEditing);
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>, key: keyof ScheduleModel) => {
    if (formData) {
      setFormData({
        ...formData,
        [key]: e.target.value
      });
    }
  };

  const handleDateChange = (date: Date | null, key: keyof ScheduleModel) => {
    if (formData) {
      setFormData({
        ...formData,
        [key]: date ? date.toISOString() : ''
      });
    }
  };

  const handleSave = async () => {
    if (formData) {
      try {
        await UpdatePmScheduleData(machineId, formData);
        setScheduleData(formData);
        setIsEditing(false);
      } catch (error: any) {
        setError('Failed to save data: ' + (error.message || 'Unknown error'));
      }
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div className="error-message">{error}</div>;
  }

  return (
    <div className="popup-container">
      <button className="close-button" onClick={onClose}>
        Close
      </button>
      <button className="edit-button" onClick={handleEditClick}>
        {isEditing ? 'Cancel' : 'Edit'}
      </button>
      <div className="form-container">
        {formData ? (
          Object.entries(formData).map(([key, value]) => (
            <div className="form-row" key={key}>
              <label className="form-label">{key}</label>
              {isEditing ? (
                key.endsWith('Schedule') || key.endsWith('Alert') || key.endsWith('After') || key === 'modified' || key === 'created' ? (
                  <DatePicker
                    selected={value ? new Date(value) : null}
                    onChange={(date) => handleDateChange(date, key as keyof ScheduleModel)}
                    className="form-input"
                    dateFormat="yyyy-MM-dd"
                  />
                ) : (
                  <input
                    type="text"
                    value={value ?? ''}
                    onChange={(e) => handleChange(e, key as keyof ScheduleModel)}
                    className="form-input"
                  />
                )
              ) : (
                <div className="form-value">{value === null ? 'N/A' : value.toString()}</div>
              )}
            </div>
          ))
        ) : (
          <div>No data available</div>
        )}
        {isEditing && (
          <button className="save-button" onClick={handleSave}>
            Save
          </button>
        )}
      </div>
    </div>
  );
};

export default MachinePopup;
