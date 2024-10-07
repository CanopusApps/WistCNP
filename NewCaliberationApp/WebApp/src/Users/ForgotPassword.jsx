import React, { useState } from 'react';
import './ForgotPassword.css'; 
import {ForgotPassword} from '../Api/Auth';
//import { useNavigate } from 'react-router-dom';

function ForgotPasswords({ onBack }) {
  const [email, setEmail] = useState('');
  const[EmpId,setEmpId] = useState('');
  const [loading, setLoading] = useState(false);
  const [message, setMessage] = useState('');
  //const navigate = useNavigate();

  const handleSubmit = async (event) => {
    event.preventDefault();
    setLoading(true);
    setMessage('');
    try {
      var result = await ForgotPassword(EmpId,email)
      const {  message: resultMessage, statusCode } = result;
      console.log(result.statusCode);
      console.log(result);
      if (statusCode === 200) {
        console.log(result.statusCode);
        alert(resultMessage);
        onBack();
      } else {
        setMessage(resultMessage);
      }
    } catch (err) {
      setMessage('An error occurred. Please try again.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="forgot-password-container">
      <div className="forgot-password-section">
        <header>
          <h2 className="animation a1">Forgot Password</h2>
          <h4 className="animation a2">Enter your email to reset your password</h4>
        </header>
        <form onSubmit={handleSubmit}>
          <input
            type="email"
            placeholder="Email"
            className="input-field animation a3"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
          <br/>
          <input
            type="EmpId"
            placeholder="EmpId"
            className="input-field animation a4"
            value={EmpId}
            onChange={(e) => setEmpId(e.target.value)}
            required
          />
          {message && <p className="message">{message}</p>}
          <p className="animation a5">
            <a
              href="#"
              className="back-to-login-link"
              onClick={onBack}
            >
              Back to Login
            </a>
          </p>
          <button
            type="submit"
            className="animation a6"
            disabled={loading}
          >
            {loading ? 'Sending...' : 'Send Reset Link'}
          </button>
        </form>
      </div>
      <div className="right"></div>
    </div> 
  );
}

export default ForgotPasswords;
