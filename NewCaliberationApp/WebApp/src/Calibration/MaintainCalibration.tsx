import React,{useState} from 'react';
import Styles from './MaintainCalibration.module.css';
import styles from "./CalibrationLog.module.css"; 


const MaintainCalibration : React.FC = () =>
{ const [assetTag, setAssetTag] = useState<string>('');
    const [calHistory, setCalHistory] = useState<boolean>(false);

    const handleSubmit = (event: React.FormEvent) => {
        event.preventDefault();
        console.log('Asset Tag:', assetTag);
        console.log('CAL.History:', calHistory);
    };
    return (
        <>
        <div>
            <label>Asset Tag</label>
            <input type='text'/>
            <label>Asset Tag</label>
            <input type='text'/>
        </div>
        <div>
        <input type="checkbox" className={styles.calHistory}id="calHistory" name="option1" value="value1" checked={calHistory} onChange={() => setCalHistory(!calHistory)} />
        <label htmlFor="calHistory">Last CAL.Date</label>
        <input type="checkbox" className={styles.calHistory}id="calHistory" name="option1" value="value1" checked={calHistory} onChange={() => setCalHistory(!calHistory)} />
        <label htmlFor="calHistory">Next CAL.Date</label>
        </div>
        <div>
            <label>FormDate</label>
            <input type='text'/>
            <label>Date To</label>
            <input type='text'/>
        </div>
        <div>
            <label>Model</label>
            <input type='text'/>
            <label>Plant ID</label>
            <input type='text'/>
        </div>
        <div>
            <label>CAL Status</label>
            <input type='text'/>
            <label>Keeper</label>
            <input type='text'/>
        </div>

<div><input type ='submit' value = 'Query'/></div>
        </>
    );
}
export default MaintainCalibration;