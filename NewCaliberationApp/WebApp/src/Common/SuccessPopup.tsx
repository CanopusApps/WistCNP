import React from 'react';
import './SuccessPopup.css';

// Define the type for props
interface SuccessPopupProps {
    isVisible: boolean;
    onClose: () => void;
    message: string;
}

const SuccessPopup: React.FC<SuccessPopupProps> = ({ isVisible, onClose, message }) => {
    if (!isVisible) return null;

    return (
        <div className="popup">
            <div className="popup-content">
                <span className="close" onClick={onClose}>&times;</span>
                <div className="wrapper">
                    <svg className="checkmark" viewBox="0 0 52 52">
                        <circle className="checkmark__circle" cx="26" cy="26" r="25" fill="none"/>
                        <path className="checkmark__check" fill="none" d="M14.1 27.2l7.1 7.2 16.7-16.8"/>
                    </svg>
                </div>
                <h2>{message}</h2>
                <p>Your action was successful.</p>
            </div>
        </div>
    );
};

export default SuccessPopup;
