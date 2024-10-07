import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Navbar from './Components/Navbar';
import Home from './Users/Home';
import User from './BaseData/AddOrDeleteUser'; 
import CalibrationList from './BaseData/CalibrationCheckList'
import ModelList from './BaseData/ModelList';
import PM from './PMMaintain/PM';
import CalSignoff from './BaseData/CalList_Signoff';
import Calibration from './Calibration/NewCalibration';
import CalibrationLog from './Calibration/CalibrationLog';
import BatchChange from './Calibration/BatchChange';
import MaintainCalibration from './Calibration/MaintainCalibration';
import './App.css';

const App = () => {
  return (
    <div style={{ display: 'flex' }}>
      <Navbar />
      <main style={{ flex: 1, padding: '1.3rem',width:'80%' }}>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/user" element={<User />} />
          <Route path="/calibrationList" element={<CalibrationList/>}/>
          <Route path="/calSignOff" element={<CalSignoff/>}/>
          <Route path="/modelList" element={<ModelList />} />
          <Route path="/newCalibration" element={<Calibration/>}/>
          <Route path="/maintaincalibration" element={<MaintainCalibration/>}/>
          <Route path="/calibrationlog" element={<CalibrationLog/>}/>
          <Route path="/batchchange" element={<BatchChange/>}/>
          <Route path="/pm" element={<PM />} />
          {/* Add more routes as needed */}
        </Routes>
      </main>
    </div>
  );
};

export default App
