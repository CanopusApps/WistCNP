import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './Navbar.css';
import { logoutUser } from '../Api/Auth';

function Navbar() {
  const [isMobileMenuOpen, setIsMobileMenuOpen] = useState(false);
  const navigate = useNavigate();

  const handleToggleMenu = () => {
    setIsMobileMenuOpen(!isMobileMenuOpen);
  };

  const handleLogout = async () => {
    try {
      sessionStorage.clear();
      await logoutUser();
    } catch (error) {
      console.error('Logout failed', error);
    }
    sessionStorage.removeItem('right');
    navigate('/');
  };

  return (
    <nav className={`sidebar ${isMobileMenuOpen ? '' : 'hidden'}`}>
      <button className="menu-toggle" onClick={handleToggleMenu}>
        &#9776; 
      </button>
      <ul className={`nav-links ${isMobileMenuOpen ? 'open' : ''}`}>
        <li><h2><Link to="/Home"><b>Home</b></Link></h2></li>
        <h3>Base Data</h3>
          {sessionStorage.getItem('right') === "CA" && <li><Link to="/Home/user">User Account</Link></li>}

          <li><Link to="/Home/CalibrationList">CalibrationList</Link></li>

          {sessionStorage.getItem('right') !== "CH" && <li><Link to="/Home/calSignOff">CalList-SignOff</Link></li>}

          <li><Link to="/Home/modelList">ModelList</Link></li>

          <h3>Calibration</h3>
          <li><Link to="/Home/newCalibration">New Calibration</Link></li>
          <li><Link to="/Home/maintaincalibration">Maintain Calibration</Link></li>
          <li><Link to="/Home/batchchange">BatchChange</Link></li>
          <li><Link to="/Home/calibrationlog">CalibrationLog</Link></li>

          <h3>Data Query</h3>
          <li><Link to="/Home/services">EquipmentList</Link></li>
          <li><Link to="/Home/pm">PM</Link></li>
          <li>
            <div className="logout">
              <a href="#" className="logout-link" onClick={handleLogout}>
                Logout
              </a>
            </div>
          </li>
      </ul>
    </nav>
  );
}

export default Navbar;
