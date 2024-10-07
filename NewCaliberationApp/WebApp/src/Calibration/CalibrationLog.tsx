import React, { useState } from 'react';
import styles from "./CalibrationLog.module.css"; 

const CalibrationLog: React.FC = () => {
    const [assetTag, setAssetTag] = useState<string>('');
    const [calHistory, setCalHistory] = useState<boolean>(false);

    const handleSubmit = (event: React.FormEvent) => {
        event.preventDefault();
        console.log('Asset Tag:', assetTag);
        console.log('CAL.History:', calHistory);
    };

    return (
        <>
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="assetTag">Asset Tag</label>
                <input  type="text"  id="assetTag" name="assetTag" value={assetTag} onChange={(e) => setAssetTag(e.target.value)}/>
            
                <input type="checkbox" className={styles.calHistory}id="calHistory" name="option1" value="value1" checked={calHistory} onChange={() => setCalHistory(!calHistory)} />
                <label htmlFor="calHistory">CAL.History</label>
            </div>
            <div>
                <label>Start Date</label>
                <input type="date"/>
                <label>End Date</label>
                <input type="date"/>
            </div>
            <div>
                <label>Model</label>
            <select name="model" value={""}  className={styles.select}>
              <option value="">Select Model</option>
            </select>

            <label>Plant</label>
            <select name="model" value={""}  className={styles.select}>
              <option value="">Select Plant</option>
            </select>
            </div>
            <div>
                <input type='submit' value={"Query"}/>
                <input type='button' value={"Save To Excel"}/>
            </div>
        </form>
        <br/>
        <hr/>
        </>
    );
};

export default CalibrationLog;
