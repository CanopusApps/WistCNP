import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './index.css';
import reportWebVitals from './reportWebVitals';
import LoginPage from './Users/Login';
import App from './App';
import NotFoundPage from './Components/NotFoundPage';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <Router>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route path="Home/*" element={<App />} /> 
        {/*<Route path="*" element={<NotFoundPage />} />*/}
        <Route path="*" element={<LoginPage/>}/>
      </Routes>
    </Router>
  </React.StrictMode>
);

reportWebVitals();
