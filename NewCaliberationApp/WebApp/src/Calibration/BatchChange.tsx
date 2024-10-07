import React from 'react';
import styles from "./BatchChange.module.css"; 

const BatchChange : React.FC =() =>
{
    return (
        <>
        <form>
            <div>
                <label>Data Field</label>
            <select name="model" value={""}  className={styles.select}>
              <option value="">Instrument Owner</option>
            </select>
            <label>Plant ID</label>
                <select name="model" value={""}  className={styles.select}>
                <option value="">Select Plant</option>
                </select>
            </div>
            <div>
            <label>Email</label>
            <input type='text' />
                <label>UserDept</label>
                <input type='text' />
            </div>
            <div>
            <label>Old Value</label>
            <input type='text' />
            <label>New Value</label>
            <input type='text' />
            </div>
            <div>
                <input type='submit' value ="Save"/>
            </div>
        </form>
        </>
    );
}
export default BatchChange;