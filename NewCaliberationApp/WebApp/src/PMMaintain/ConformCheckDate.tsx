import React, { useState, useEffect } from 'react';
import './ConformCheckDate.css';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css';
import { updateMachineCheck } from '../Api/PMApi'; 
import SuccessPopup from '../Common/SuccessPopup';

interface CheckConformProps {
  machineId: string;
  onClose: () => void;
}

const CheckConform: React.FC<CheckConformProps> = ({ machineId, onClose }) => {
  const [isChecked, setIsChecked] = useState<boolean>(false);
  const [selectedDate, setSelectedDate] = useState<Date | null>(null);
  const [message, setMessage] = useState<string | null>(null);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [isSuccessPopupVisible, setSuccessPopupVisible] = useState<boolean>(false);

  const handleCheckboxChange = () => {
    setIsChecked(prev => !prev);
    if (!isChecked) {
      // If checkbox is checked, we keep the selectedDate as it is
      // If checkbox is unchecked, we set the selectedDate to current date if it is null
      if (selectedDate === null) {
        setSelectedDate(new Date());
      }
    } else {
      setSelectedDate(null); 
    }
  };

  const handleDateChange = (date: Date | null) => {
    setSelectedDate(date);
  };

  const handleUpdate = async () => {
    setIsLoading(true);
    setMessage(null);

    try {
      const dateToUpdate = isChecked && selectedDate ? selectedDate : new Date();
      
      var response = await updateMachineCheck(machineId, dateToUpdate);
      if(response.statusCode===200)
      {
      setMessage('Machine check updated successfully.');
      setSuccessPopupVisible(true);
      
      setTimeout(() => {
        setSuccessPopupVisible(false);
        onClose();
      }, 3000);
    }
    else{
      console.error("response");
      alert(response);
    }
    } catch (error) {
      const errorMessage = error instanceof Error ? error.message : 'Unknown error';
      setMessage('Update failed: ' + errorMessage);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
  }, [machineId]);

  return (
    <div className="popup-containers">
      <button className="close-buttons" onClick={onClose}>
        x
      </button>
      <h2 id="modal-title">Update Status for Machine: {machineId}</h2>
      <div className="form-group">
        <label htmlFor="date-checkbox">
          <input
            type="checkbox"
            id="date-checkbox"
            checked={isChecked}
            onChange={handleCheckboxChange}
          />
          Select to enter a date
        </label>
      </div>
      {isChecked && (
        <div className="form-group">
          <DatePicker
            selected={selectedDate}
            onChange={handleDateChange}
            dateFormat="yyyy/MM/dd"
            placeholderText="Select a date"
            aria-labelledby="date-picker"
            disabled={isLoading}
          />
        </div>
      )}
      <p className="status-message" aria-live="polite">
        {isLoading ? 'Updating...' : message}
      </p>
      <button onClick={handleUpdate} disabled={isLoading}>
        {isLoading ? 'Updating...' : 'Update'}
      </button>
      
      <SuccessPopup
        isVisible={isSuccessPopupVisible}
        onClose={() => setSuccessPopupVisible(false)}
        message={"Machine check updated successfully."}
      />
    </div>
  );
};

export default CheckConform;
