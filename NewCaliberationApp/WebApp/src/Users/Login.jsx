import React, { useState } from 'react';
import { loginUser } from '../Api/Auth'; 
import ForgotPasswords from './ForgotPassword'; 
import './Login.css';
import { useNavigate } from 'react-router-dom';
 
function Login() {
  const [isForgotPassword, setIsForgotPassword] = useState(false);
  const [empId, setEmpId] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleLoginSubmit = async (event) => {
    event.preventDefault();
    setLoading(true);
    setError('');

    try {
      const result = await loginUser(empId, password);
      const { data, message, statusCode } = result;
      console.log(statusCode);
      if (statusCode===200) {
        navigate('/Home');
        sessionStorage.setItem('empId', data.empId);
        sessionStorage.setItem('right', data.right);
        sessionStorage.setItem('empName', data.empName);
        sessionStorage.setItem('email',data.email)
        sessionStorage.setItem('checkListApprover',data.checkListApprover)
        sessionStorage.setItem('accessToken', data.accessToken);
      } else if (statusCode === 400) {
        alert("Please check the EmpId or Password");
      }
      else{
        alert(message);
      }
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  const handleForgotPasswordClick = () => {
    setIsForgotPassword(true);
  };

  const handleBackToLogin = () => {
    setIsForgotPassword(false);
  };

  if (isForgotPassword) {
    return <ForgotPasswords onBack={handleBackToLogin} />;
  }

  return (
    <div className="container">
      <div className="left">
        <div className="login-section">
          <header>
            <h2 className="animation a1">Calibration System</h2>
            <h4 className="animation a2">
              Welcome back, Please login to your account
            </h4>
          </header>
          <form onSubmit={handleLoginSubmit}>
            <input
              type="text"
              placeholder="EmpId"
              className="input-field animation a3"
              value={empId}
              onChange={(e) => setEmpId(e.target.value)}
              required
            />
            <input
              type="password"
              placeholder="Password"
              className="input-field animation a4"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
            {error && <p className="error">{error}</p>}
            <p className="animation a5">
              <a
                href="#"
                className="forgot-password-link"
                onClick={handleForgotPasswordClick}
              >
                Forgot password?
              </a>
            </p>
            <button
              type="submit"
              className="animation a6"
              disabled={loading}
            >
              {loading ? 'Signing in...' : 'Sign in'}
            </button>
          </form>
        </div>
      </div>
      <div className="right"></div>
    </div>
  );
}

export default Login;
