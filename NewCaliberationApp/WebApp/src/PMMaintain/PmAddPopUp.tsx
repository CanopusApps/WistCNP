import React, { useState } from 'react';
import DatePicker from 'react-datepicker';
import "react-datepicker/dist/react-datepicker.css";
import { MachineData } from '../Models/PmModels';
import { AddPMMachine } from '../Api/PMApi';
import './PmAddPopUp.css';

interface AddMachinePopupProps {
  onClose: () => void;
}

const AddMachinePopup: React.FC<AddMachinePopupProps> = ({ onClose }) => 
  {
  const [formData, setFormData] = useState<MachineData>({
    machineIdSn: '',
    machineName: '',
    project: '',
    line: '',
    subLine: '',
    machineLocation: '',
    make: '',
    checklistNo: '',
    machineCategory: '',
    tataDRIName: '',
    pmManager: '',
    firstTimePmScheduleDate: '',
    frequency: '',
    pmDurationHrs: '',
    actualPmDate: null,
    pmAdherence: '',
    currentPmStatus: false,
    engineeringManager: '',
    dccCheckListLink: '',
    toolList: '',
    isCheck: false,
    lastCheck: '',
    vendorDRI: '',
  });

  const [error, setError] = useState<string | null>(null);
  const [formErrors, setFormErrors] = useState<{ [key: string]: string }>({});

  const validateForm = () => {
    const errors: { [key: string]: string } = {};

    if (!formData.machineIdSn) errors.machineIdSn = 'required';
    if (!formData.machineName) errors.machineName = 'required';
    if (!formData.make) errors.make = 'required';
    if (!formData.project) errors.project = 'required';
    if (!formData.line) errors.line = 'required';
    if (!formData.tataDRIName) errors.tataDRIName = 'required';
    if (!formData.pmManager) errors.pmManager = 'required';
    if (!formData.firstTimePmScheduleDate) errors.firstTimePmScheduleDate = 'required';
    if (!formData.frequency) errors.frequency = 'required';
    if (!formData.lastCheck) errors.frequency = 'required';

    setFormErrors(errors);
    return Object.keys(errors).length === 0;
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>, key: keyof MachineData) => {
    const value = key === 'isCheck' || key === 'currentPmStatus' ? e.target.checked : e.target.value;
    setFormData(prev => ({
      ...prev,
      [key]: value
    }));
  };

  const handleDateChange = (date: Date | null, key: keyof MachineData) => {
    setFormData(prev => ({
      ...prev,
      [key]: date ? date.toISOString().split('T')[0] : ''
    }));
  };

  const handleSave = async () => {
    if (!validateForm()) return; 

    try {
      await AddPMMachine(formData);
      onClose(); 
    } catch (error: any) {
      setError('Failed to save data: ' + (error.message || 'Unknown error'));
    }
  };

  return (
    <div className="popup-container">
      <button className="close-button" onClick={onClose}>
        <b>X</b>
      </button>
      <div className="form-container">
        {error && <div className="error-message">{error}</div>}
        {Object.entries(formData).map(([key, value]) => (
          <div className="form-row" key={key}>
            <label className={`form-label ${['machineIdSn','lastCheck','frequency', 'machineName', 'make', 'project', 'line', 'firstTimePmScheduleDate', 'pmManager', 'tataDRIName'].includes(key) ? 'required-label' : ''}`}>
              {key.replace(/([A-Z])/g, ' $1').toUpperCase()}
            </label>
            {key.endsWith('Date') || key === 'lastCheck'? (
              <DatePicker
                selected={value ? new Date(value) : null}
                onChange={(date) => handleDateChange(date, key as keyof MachineData)}
                className="form-input"
                dateFormat="yyyy-MM-dd"
              />
            ) : key === 'isCheck' || key === 'currentPmStatus' ? (
              <input
                type="checkbox"
                checked={!!value}
                onChange={(e) => handleChange(e, key as keyof MachineData)}
                className="form-input"
              />
            ) : (
              <input
                type="text"
                value={value ?? ''}
                onChange={(e) => handleChange(e, key as keyof MachineData)}
                className="form-input"
              />
            )}
            {formErrors[key] && <div className="field-error">{formErrors[key]}</div>}
          </div>
        ))}
        <button className="save-button" onClick={handleSave}>
          Save
        </button>
      </div>
    </div>
  );
};

export default AddMachinePopup;
