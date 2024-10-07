import React from 'react';
import style from './Home.module.css';
import { TypeAnimation } from 'react-type-animation';

const Home = () => {
  // Retrieve session details
  const empId = sessionStorage.getItem('empId');
  const empName = sessionStorage.getItem('empName');
  const right = sessionStorage.getItem('right');

  return (
    <div class ="main">
      {/*  <h1>Home Page</h1>
    <h2>Session Details:</h2>
      <p><strong>Rights:</strong> {right ? right : 'Not available'}</p>
      <p><strong>Employee ID:</strong> {empId ? empId : 'Not logged in'}</p>
     <p class ="name"><strong>WelCome Back</strong> </p>*/}
     <h3 className={style.emp}>
      <TypeAnimation
  sequence={[
    // Same substring at the start will only be typed once, initially
    'Welcome Back',
    1000,
    `Welcome Back ${empName}`,
    1000,
    `Welcome Back ${empName}`,
    1000,
    `Welcome Back ${empName}`,
    1000,
  ]}
  speed={50}
  style={{ fontSize: '2em' }}
  repeat={Infinity}
/>
</h3>
     
    </div>
  );
};

export default Home;
