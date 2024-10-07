import "./CalibrationCheckList.css";
import React, { useState, useEffect } from "react";
import { GetCalCheckList, DeleteCalList ,AddOrUpdateCalCheckList,ExcelDownload} from '../Api/BaseData';
import { CalListModel,CalListFilterModel, initialCalFilter,AddCalListModel } from "../Models/BaseDataModels";
import Loading from '../Common/Loading';
import SuccessPopup from "../Common/SuccessPopup";
import ConfirmationPopup from "../Common/ConfirmationPopup";
import {downloadCSV,formatDate,GetCalCycle} from "../Api/GlobalApi";
import { DropDownModel} from "../Models/UserModels";

const CalibrationList: React.FC = () => {
  const [approver, setApprover] = useState<string>('');
  const [calCheckList, setCalCheckList] = useState<CalListModel[]>([]);
  const [calCycle, setCalCycle] = useState<DropDownModel[]>([]);
  const [cycle, setCycle] = useState<string>("");
  const [statues, setStatues] = useState<string>("0");
  const [searchName, setSearchName] = useState<string>("");
  const [pubDate, setPubDate] = useState<string>("");
  const [criteria, setCriteria] = useState<string>("");
  const [loading, setLoading] = useState<boolean>(true);
  const [calFilter, setCalFilter] = useState<CalListFilterModel>(initialCalFilter);
  const [calListId, setCalListId] = useState<string>("");
  const [error, setError] = useState<string | null>(null);
  const [isPopupOpen, setPopupOpen] = useState<boolean>(false);
  const [isSuccessPopupVisible, setSuccessPopupVisible] = useState<boolean>(false);
  const [successMessage, setSuccessMessage] = useState<string>('');
  const [remark, setRemark] = useState<string>('');

  useEffect(() => {
    const empName = sessionStorage.getItem('checkListApprover');
    if (empName) {
      setApprover(empName);
    }
    GetData();
  }, [calFilter]);

  const GetData = async () => {
    try {
      const response = await GetCalCheckList(calFilter,false);
      setCalCheckList(response.data);
      const cycle = await GetCalCycle();
      setCalCycle(cycle.data);
    } catch (err) {
      setError(`Error fetching data: ${(err as Error).message}`);
    } finally {
      setLoading(false);
    }
  };

  const SelectDataTransfer = (calIndex: CalListModel) => {
    setSearchName(calIndex.name);
    setCycle(calIndex.cycle);
    setCriteria(calIndex.criteria);
    setCalListId(calIndex.id);
    setStatues(calIndex.status.toString());
    setPubDate(formatDate(calIndex.pubDate));
  };

  const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setCycle(event.target.value);
  };


  const Filter = (event: React.FormEvent) => {
    event.preventDefault();
    setCalFilter(prevFilter => ({
      ...prevFilter,
      searchName,
      calCycle: cycle,
      pubDate,
      criteria,
      status: statues
    }));
  };

  const CalListDelete = () => {
    setPopupOpen(true);
  };

  const handleConfirm = async () => {
    if (!calListId) return;

    try {
      const response = await DeleteCalList(calListId);
      if (response.statusCode === 200) {
        setCalCheckList(prevList => prevList.filter(calList => calList.id !== calListId));
        setSuccessMessage("User Deleted Successfully");
        setSuccessPopupVisible(true);
        setTimeout(() => setSuccessPopupVisible(false), 3000);
        clear();
      } else {
        setError(`Error: ${response.message}`);
      }
    } catch (error) {
      setError(`An error occurred: ${(error as Error).message}`);
    } finally {
      setPopupOpen(false);
      setCalListId("");
    }
  };

  const handleCancel = () => {
    setCalListId("");
    setPopupOpen(false);
  };

  const clear = async () => {
    setSearchName("");
    setCycle("");
    setCriteria("");
    setPubDate("");
    setStatues("");
    setCalFilter(initialCalFilter);
    setRemark("");
    setCalListId("");
    try {
      const response = await GetCalCheckList(initialCalFilter,false);
      setCalCheckList(response.data);
    } catch (err) {
      setError(`Error fetching data: ${(err as Error).message}`);
    }
  };

  const handleSubmit = async(event: React.FormEvent) => {
    event.preventDefault();
    const newModel: AddCalListModel = {
      id:calListId,
      name: searchName,
      cycle,
      criteria,
      pubDate,
      status:parseInt(statues), 
      remarks: remark,
      approver 
    }
    const response = await AddOrUpdateCalCheckList(newModel);

    console.log(response);
    await clear();
    await GetData();
  };
  const handleDownloadExcel= async()=>
  {
    const response = await ExcelDownload(calCheckList);
    if (response.statusCode===200)
    {
      const data = response.data;
      downloadCSV(data?data:"","CalChickList");
      alert(response.data)
    }
    else{
      alert(response.message)
    }
  }

  if(error!=null)  { alert(error); setError(null); }

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Name</label>
          <input type="text" className='calinput' value={searchName} onChange={(e) => setSearchName(e.target.value)} />
          <label>Approver</label>
          <input type="text" className='calinput' value={approver} readOnly />
        </div>
        <div>
          <label>Cycle</label>
          <select className='calinput' value={cycle} onChange={handleChange}>
            <option value="" disabled>Cycle Period</option>
            {calCycle.map((item, index) => (
              <option key={index} value={item.data}>{item.data}</option>
            ))}
          </select>
          <label>Pub.Date</label>
          <input type="date" className='calinput' value={pubDate} onChange={(e) => setPubDate(e.target.value)} />
        </div>
        <div>
          <label>Criteria</label>
          <input type="text" className='calinput' value={criteria} onChange={(e) => setCriteria(e.target.value)} />
        </div>
        <div>
        {calListId!=="" &&(
          <>
          <label>Status:</label>
          <select className='calinput' value={statues} onChange={(e) => setStatues(e.target.value)}>
            <option value="">Select Status</option>
            <option value={0}>Pending</option>
            <option value={1}>Accept</option>
            <option value={2}>Reject</option>
          </select>
          </>)}
          <button type="button" className='callistbut' onClick={Filter}>Query</button>
          <button type="button" className='callistbut' onClick={clear}>Clear</button>
        </div>
        <div>
          <label>Remarks</label>
          <input type="text" className='calinput' value={remark} onChange={(e) => setRemark(e.target.value)} />
        </div>
        <div>
          <button type="submit" className='callistbut'>{calListId!==""?'Update':'Save'}</button>
         {calListId!==""&&( <button type="button" className='callistbut' onClick={CalListDelete}>Delete</button>)}
         {/* <button type="button" className='callistbut'>Update</button>*/}
          <button type="button" className='callistbut' onClick={handleDownloadExcel}>Excel</button>
        </div>
      </form>
      <br />
      <hr />
      <br />
      <div>
        {loading ? (
          <Loading />
        ) : (
          <div className="table">
            <table className="record">
              <thead>
                <tr>
                  <td>Action</td>
                  <td>SerialNo</td>
                  <td>Name</td>
                  <td>Calibration Cycle(M)</td>
                  <td>Acceptance Criteria</td>
                  <td>Approver</td>
                  <td>Publication Date</td>
                  <td>Remark</td>
                  <td>Status</td>
                  <td>Comments</td>
                </tr>
              </thead>
              <tbody>
                {calCheckList.map((cal, index) => (
                  <tr key={index}>
                    <td><a className="delete" onClick={() => SelectDataTransfer(cal)} href="#">Select</a></td>
                    <td>{cal.serialNo}</td>
                    <td>{cal.name}</td>
                    <td>{cal.cycle}</td>
                    <td>{cal.criteria}</td>
                    <td>{cal.approver}</td>
                    <td>{formatDate(cal.pubDate)}</td>
                    <td>{cal.remarks}</td>
                    <td>{cal.status === 1 ? "Approved" : cal.status === 2 ? "Rejected" : "Pending"}</td>
                    <td>{cal.comments}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </div>
      <ConfirmationPopup
        isOpen={isPopupOpen}
        onConfirm={handleConfirm}
        onCancel={handleCancel}
        title="Confirm Deletion"
        message="Are you sure you want to delete this item?"
      />
      <SuccessPopup
        isVisible={isSuccessPopupVisible}
        onClose={() => setSuccessPopupVisible(false)}
        message={successMessage}
      />
    </div>
  );
}

export default CalibrationList;
