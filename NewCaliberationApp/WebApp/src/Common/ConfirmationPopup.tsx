import React from 'react';
import './ConfirmationPopup.css'; // Make sure to import your CSS

interface ConfirmationPopupProps {
    isOpen: boolean;
    onConfirm: () => Promise<void>;
    onCancel: () => void;
    title: string;
    message: string;
}

const ConfirmationPopup: React.FC<ConfirmationPopupProps> = ({ isOpen, onConfirm, onCancel, title, message }) => {
    if (!isOpen) return null;

    return (
        <div className="modal-overlay">
            <div className={`modal-content ${isOpen ? 'show' : ''}`}>
                <h2>{title}</h2>
                <p>{message}</p>
                <div className="modal-buttons">
                    <button className="confirm-btn" onClick={onConfirm}>Confirm</button>
                    <button className="cancel-btn" onClick={onCancel}>Cancel</button>
                </div>
            </div>
        </div>
    );
};

export default ConfirmationPopup;
