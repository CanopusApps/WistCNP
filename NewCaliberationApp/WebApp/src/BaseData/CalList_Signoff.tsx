import './CalList_Signoff.css';
import React, { useState, useEffect } from 'react'; 
import { CalListModel, CalListFilterModel, initialCalFilter, CalApprove } from '../Models/BaseDataModels';
import { GetCalCheckList, ApproveOrRejectCalSignOff } from '../Api/BaseData';
import { formatDate } from '../Api/GlobalApi';

const CalSignoff: React.FC = () => {
    const [calCheckList, setCalCheckList] = useState<CalListModel[]>([]);
    const [calFilter, setCalFilter] = useState<CalListFilterModel>(initialCalFilter);
    const [comments, setComments] = useState<string>("");
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        GetData();
    }, [calFilter]);

    const GetData = async () => {
        try {
            const response = await GetCalCheckList(calFilter, true);
            setCalCheckList(response.data);
            setError(null);
        } catch (err) {
            console.error(err);
            setError("Failed to fetch data.");
        }
    };

    const singleApproveHandle = async (cal: CalListModel, isApprove: boolean) => {
        if (comments.trim() === "") {
            alert("Comment Required");
            return;
        }
        
        try {
            setLoading(true);
            const calApprove: CalApprove = {
                id: [cal.id],
                isApprove: isApprove,
                comment: comments
            };
            await ApproveOrRejectCalSignOff(calApprove);
            alert("Status updated successfully.");
            GetData();
        } catch (err) {
            console.error(err);
            alert("Failed to process request.");
        } finally {
            setLoading(false);
        }
    };

    const HandleApproveOrRejectAll = async (isApprove: boolean) => {
        if (comments.trim() === "") {
            alert("Comment Required");
            return;
        }
        
        if (calCheckList.length === 0) {
            alert("No records to approve or reject.");
            return;
        }
        
        try {
            setLoading(true);
            const ids = calCheckList.map(item => item.id);
            const calApprove: CalApprove = {
                id: ids,
                isApprove: isApprove,
                comment: comments
            };
            await ApproveOrRejectCalSignOff(calApprove);
            alert("Status updated successfully.");
            GetData();
            setComments(""); 
        } catch (err) {
            console.error(err);
            alert("Failed to process request.");
        } finally {
            setLoading(false);
        }
    };

    const setCommentHandle = (event: React.ChangeEvent<HTMLTextAreaElement>) => {
        setComments(event.target.value);
    };

    const areCommentsValid = comments.trim() !== "";
    const isCalCheckListEmpty = calCheckList.length === 0;

    return (
        <>
            <form className='signoffform' onSubmit={(e) => e.preventDefault()}>
                <div className='commentBox'>
                    <label>Comments</label>
                    <textarea 
                        id="message" 
                        name="message" 
                        rows={4} 
                        cols={50} 
                        style={{ margin: '10px' }} 
                        value={comments}
                        onChange={setCommentHandle} 
                        required 
                    />
                </div>
                <div>
                    <button 
                        className='calaccept' 
                        onClick={() => HandleApproveOrRejectAll(true)} 
                        disabled={loading || isCalCheckListEmpty}
                    >
                        Accept All
                    </button>
                    <button 
                        className='calreject' 
                        onClick={() => HandleApproveOrRejectAll(false)} 
                        disabled={loading  || isCalCheckListEmpty}
                    >
                        Reject All
                    </button>
                </div>
                {isCalCheckListEmpty && <div className="warning">No records to approve or reject.</div>}
            </form>
            {error && <div className="error">{error}</div>}
            {loading && <div className="spinner">Loading...</div>}
            <hr />
            <table className="record">
                <thead>
                    <tr>
                        <th>Reject</th>
                        <th>Accept</th>
                        <th>Serial ID</th>
                        <th>Need CAL?</th>
                        <th>Name</th>
                        <th>Calibration cycle (M)</th>
                        <th>Acceptance Criteria</th>
                        <th>Approver</th>
                        <th>Publication Date</th>
                        <th>Remark</th>
                    </tr>
                </thead>
                <tbody>
                    {calCheckList.map(item => (
                        <tr key={item.id}> 
                            <td><button className ="cbtn" onClick={() => singleApproveHandle(item, false)}>Reject</button></td>
                            <td><button className ="cbtns" onClick={() => singleApproveHandle(item, true)}>Accept</button></td>
                            <td>{item.serialNo}</td>
                            <td>{item.status === 0 ? 'Yes' : item.status}</td>
                            <td>{item.name}</td>
                            <td>{item.cycle}</td>
                            <td>{item.criteria}</td>
                            <td>{item.approver}</td>
                            <td>{formatDate(item.pubDate)}</td>
                            <td>{item.remarks}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    );
}

export default CalSignoff;
