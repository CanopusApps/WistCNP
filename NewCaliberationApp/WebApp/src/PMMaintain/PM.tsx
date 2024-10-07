import React, { useState, useEffect, useCallback } from 'react';
import { PMAddExcel, PmGetAll, PmItemDelete } from '../Api/PMApi';
import { MachineData } from '../Models/PmModels';
import './PM.css';
import MachinePopup from './PmPopUp';
import CheckConform from './ConformCheckDate';
import AddMachinePopup from './PmAddPopUp';
import ConfirmationPopup from '../Common/ConfirmationPopup';
import SuccessPopup from '../Common/SuccessPopup';
import Loading from '../Common/Loading';

const PM: React.FC = () => {
  const [file, setFile] = useState<File | null>(null);
  const [uploading, setUploading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);
  const [machines, setMachines] = useState<MachineData[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [selectedMachineId, setSelectedMachineId] = useState<string | null>(null);
  const [selectCheckMachineId, setSelectCheckMachineId] = useState<string | null>(null);
  const [showUploadForm, setShowUploadForm] = useState<boolean>(true);
  const [showAddMachinePopup, setShowAddMachinePopup] = useState<boolean>(false);
  const [userToDelete, setUserToDelete] = useState<string | null>(null);
  const [isPopupOpen, setPopupOpen] = useState<boolean>(false);
  const [isSuccessPopupVisible, setSuccessPopupVisible] = useState<boolean>(false);
  const [successMessage, setSuccessMessage] = useState<string>('');
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [pageNumber, setPageNumber] = useState<number>(1);
  const [pageSize, setPageSize] = useState<number>(10);
  const [totalCount, setTotalCount] = useState<number>(0);

  const fetchMachines = useCallback(async () => {
    setLoading(true);
    try {
      const result = await PmGetAll(searchTerm, pageNumber, pageSize);
      setMachines(result.data || []);
      setTotalCount(result.totalCount || 0);
    } catch (error: any) {
      setError(error.message);
    } finally {
      setLoading(false);
    }
  }, [searchTerm, pageNumber, pageSize]);

  useEffect(() => {
    fetchMachines();
  }, [fetchMachines]);

  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.files && event.target.files[0]) {
      const selectedFile = event.target.files[0];
      if (selectedFile.type !== 'application/vnd.ms-excel' && selectedFile.type !== 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet') {
        setError('Invalid file type. Please upload an Excel file.');
        return;
      }
      setFile(selectedFile);
    }
  };

  const handleDelete = (PmId: string) => {
    setUserToDelete(PmId);  
    setPopupOpen(true); 
  };

  const handleConfirmDelete = async () => {
    if (userToDelete) {
      try {
        const response = await PmItemDelete(userToDelete);
        if (response.statusCode === 400) {
          alert(response.message);
        } else {
          setSuccessMessage('Machine deleted successfully.');
          setSuccessPopupVisible(true);
          fetchMachines();
        }
      } catch (error: any) {
        setError(`Delete failed: ${error.message || 'Unknown error'}`);
      } finally {
        setPopupOpen(false);
        setUserToDelete(null);
      }
    }
  };

  const handleCancel = () => {
    setPopupOpen(false);
    setUserToDelete(null); 
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    if (!file) {
      setError('Please select a file to upload.');
      return;
    }

    setUploading(true);
    setError(null);

    try {
      const response = await PMAddExcel(file);
      if (response.statusCode === 400) {
        fetchMachines();
        alert(response.message);
      } else {
        setSuccessMessage('File uploaded successfully.');
        setSuccessPopupVisible(true);
        fetchMachines();
      }
    } catch (error: any) {
      setError(`Upload failed: ${error.message || 'Unknown error'}`);
    } finally {
      setUploading(false);
    }
  };

  const handlePopupClose = useCallback(async () => {
    setSelectedMachineId(null);
    setSelectCheckMachineId(null);
    setShowAddMachinePopup(false);
    setShowUploadForm(true); 
    fetchMachines();
  }, [fetchMachines]);

  const handlePageChange = (newPage: number) => {
    setPageNumber(newPage);
  };

  const handlePageSizeChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setPageSize(parseInt(event.target.value, 10));
    setPageNumber(1); 
  };

  const ShowOption = () => {
    setShowUploadForm(prev => !prev);
    setShowAddMachinePopup(prev => !prev);
  };
  

  return (
      <div className='headerBlock'>
      <div className="toggle-switch">
        <label className="switch">
          <input
            type="checkbox"
            checked={showUploadForm}
            onChange={() => ShowOption()}
          />
           <span className="slider"></span>
        </label>
        <span>{showUploadForm?'Bulk Upload':'Single Record'}</span>
      </div>

      {showUploadForm && (
        <div>
        <form onSubmit={handleSubmit} className="upload-form">
          <div className="form-group">
            <label htmlFor="fileInput">Select file:</label>
            <input
              type="file"
              id="fileInput"
              onChange={handleFileChange}
              accept=".xls,.xlsx"
            />
          </div>
          <button type="submit" disabled={uploading} className="submit-button">
            {uploading ? 'Uploading...' : 'Upload'}
          </button>
          {error && <p className="error-message">{error}</p>}
        </form>
      

      <hr/>
      <div className="search-box">
        <div className="search-container">
          <input
            type="text"
            className="search-input"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            placeholder="Search..."
          />
          <button className="search-button" onClick={fetchMachines}>🔍</button>
        </div>
      </div>
      <div className="table-container">
        {loading?  (<Loading/>
        ) : (
          <table className="table-pm">
            <thead>
              <tr>
                <th>Machine ID</th>
                <th>Machine Name</th>
                <th>Last Check Date</th>
                <th>Is Checked</th>
                <th>Location</th>
                <th>Project</th>
                <th>Make</th>
                <th>Category</th>
                <th>Vendor DRI</th>
                <th>Frequency</th>
                <th>Checklist No</th>
                <th>First Time PM Schedule Date</th>
                <th>Actual PM Date</th>
                <th>PM Adherence</th>
                <th>Current PM Status</th>
                <th>PM Manager</th>
                <th>Engineering Manager</th>
                <th>DCC Check List Link</th>
                <th>Tool List</th>
                <th>Line</th>
                <th>Sub Line</th>
                <th>Machine Location</th>
                <th>Tata DRI Name</th>
                <th>PM Duration Hrs</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {machines.map((machine, index) => (
                <tr key={index}>
                 
                  <td>
                    <a className="code"
                      href="#"
                      onClick={() => setSelectedMachineId(machine.machineIdSn)}
                      role="button"
                      aria-label={`View details for machine ${machine.machineIdSn}`}
                    >
                      {machine.machineIdSn}
                    </a>
                  </td>
                  <td>{machine.machineName}</td>
                  <td>{machine.lastCheck || 'N/A'}</td>
                  <td style={{ color: machine.isCheck ? 'green' : 'red' }}>
                    {machine.isCheck ? 'Checked' : 
                      <a 
                        href="#" 
                        style={{ color: 'red', textDecoration: 'underline' }}
                        onClick={() => setSelectCheckMachineId(machine.machineIdSn)}
                        role="button"
                        aria-label={`Mark machine ${machine.machineIdSn} as checked`}
                      >
                        Not Checked
                      </a>
                    }
                  </td>
                  <td>{machine.machineLocation}</td>
                  <td>{machine.project}</td>
                  <td>{machine.make}</td>
                  <td>{machine.machineCategory}</td>
                  <td>{machine.vendorDRI}</td>
                  <td>{machine.frequency}</td>
                  <td>{machine.checklistNo}</td>
                  <td>{machine.firstTimePmScheduleDate || 'N/A'}</td>
                  <td>{machine.actualPmDate || 'N/A'}</td>
                  <td>{machine.pmAdherence || 'N/A'}</td>
                  <td>{machine.currentPmStatus ? 'Yes' : 'No'}</td>
                  <td>{machine.pmManager}</td>
                  <td>{machine.engineeringManager}</td>
                  <td>
                    <a
                      className='link'
                      href={machine.dccCheckListLink}
                      target="_blank"
                      rel="noopener noreferrer"
                      aria-label={`DCC Checklist Link for machine ${machine.machineIdSn}`}
                    >
                      {machine.dccCheckListLink || 'N/A'}
                    </a>
                  </td>
                  <td>{machine.toolList || 'N/A'}</td>
                  <td>{machine.line}</td>
                  <td>{machine.subLine}</td>
                  <td>{machine.machineLocation}</td>
                  <td>{machine.tataDRIName}</td>
                  <td>{machine.pmDurationHrs || 'N/A'}</td>
                  <td>
                    <a
                      className="delete"
                      onClick={() => handleDelete(machine.machineIdSn)}
                      role="button"
                      aria-label={`Delete machine ${machine.machineIdSn}`}
                    >
                      ❌
                    </a>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        )}

        <div className="search-pagination-controls">
          <div className="pagination-controls">
            <select value={pageSize} onChange={handlePageSizeChange}>
              <option value={10}>10</option>
              <option value={15}>15</option>
              <option value={20}>20</option>
            </select>
            <button
              style={{background:'transparent',color: 'wheat'}}
              onClick={() => handlePageChange(pageNumber - 1)}
              disabled={pageNumber === 1}
            >
              Previous
            </button>
            <span>Page {pageNumber} of {Math.ceil(totalCount / pageSize)}</span>
            <button
              className='tableButton'
              style={{background:'transparent',color: 'wheat'}}
              onClick={() => handlePageChange(pageNumber + 1)}
              disabled={pageNumber * pageSize >= totalCount}
            >
              Next
            </button>
          </div>
        </div>
      </div>
      </div>
      )}
      {selectedMachineId && (
        <MachinePopup machineId={selectedMachineId} onClose={handlePopupClose} />
      )}
      {selectCheckMachineId && (
        <CheckConform machineId={selectCheckMachineId} onClose={handlePopupClose} />
      )}
      {showAddMachinePopup && (
        <AddMachinePopup onClose={handlePopupClose} />
      )}
      <ConfirmationPopup
        isOpen={isPopupOpen}
        onConfirm={handleConfirmDelete}
        onCancel={handleCancel}
        title="Confirm Deletion"
        message="Are you sure you want to delete this machine?"
      />
      <SuccessPopup
        isVisible={isSuccessPopupVisible}
        onClose={() => setSuccessPopupVisible(false)}
        message={successMessage}
      />
    </div>
  );
};

export default PM;
