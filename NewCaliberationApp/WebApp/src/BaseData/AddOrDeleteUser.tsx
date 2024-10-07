import React, { useState, useEffect, ChangeEvent, FormEvent, FocusEvent } from 'react';
import './AddOrDeleteUser.css';
import { UserList, DeleteUse, GetHrAtUser, AddUser } from '../Api/BaseData'; 
import ConfirmationPopup from '../Common/ConfirmationPopup';
import SuccessPopup from '../Common/SuccessPopup';
import Loading from '../Common/Loading';
import {UserListResponse,UserType} from '../Models/UserModels';


const User: React.FC = () => {
  const [newUser, setNewUser] = useState<UserType>({
    emplId: '',
    userName: '',
    userID: '',
    department: '',
    userRole: '',
    password: '' 
  });
  const [users, setUsers] = useState<UserListResponse[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [employeeID, setEmployeeID] = useState<string>('');
  const [isPopupOpen, setPopupOpen] = useState<boolean>(false);
  const [userToDelete, setUserToDelete] = useState<string | null>(null);
  const [isSuccessPopupVisible, setSuccessPopupVisible] = useState<boolean>(false);
  const [successMessage, setSuccessMessage] = useState<string>('');

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const result = await UserList();
        setUsers(result.data); 
      } catch (err) {
        setError(`Error fetching users: ${(err as Error).message}`);
      } finally {
        setLoading(false);
      }
    };

    fetchUsers();
  }, []);

  const handleInputChange = (e: ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setNewUser(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleAddUser = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    try {
      const result = await AddUser(newUser);
      if (result.statusCode === 200) {
        setSuccessMessage("User Added");
        setSuccessPopupVisible(true);
        
        const updatedUsers = await UserList();
        setUsers(updatedUsers.data);
        setNewUser({
          emplId: '',
          userName: '',
          userID: '',
          department: '',
          userRole: '',
          password: '' 
        });
        setTimeout(() => {
          setSuccessPopupVisible(false);
        }, 3000); 
      } else {
        alert(result.data.data.message);
      }
    } catch (err) {
      setError(`Error adding user: ${(err as Error).message}`);
    }
  };

  const fetchEmployeeData = async (id: string) => {
    if (!id) {
      setNewUser(prev => ({
        ...prev,
        userName: '',
        department: ''
      }));
      return;
    }

    try {
      const response = await GetHrAtUser(id.toUpperCase());
      if (response.statusCode === 200) {
        const { userName, department } = response.data;
        setNewUser(prev => ({
          ...prev,
          userName: userName || '',
          department: department || ''
        }));
      } else {
        setNewUser(prev => ({
          ...prev,
          userName: '',
          department: ''
        }));
        alert(response.message);
      }
    } catch (error) {
      alert(error);
      console.error('Error fetching data:', error);
      setNewUser(prev => ({
        ...prev,
        userName: '',
        department: ''
      }));
      setError('Failed to fetch data. Please try again.');
    }
  };

  const handleEmployeeIDChange = (event: ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;
    setEmployeeID(value);
    setNewUser(prev => ({
      ...prev,
      emplId: value
    }));
  };

  const handleEmployeeIDBlur = () => {
    fetchEmployeeData(employeeID);
  };

  const handleDelete = (id: string) => {
    setUserToDelete(id);
    setPopupOpen(true);
  };

  const handleConfirm = async () => {
    if (userToDelete == null) return;

    try {
      const response = await DeleteUse(userToDelete);
      console.log(response);

      if (response.statusCode === 200) {
        setUsers(prevUsers => prevUsers.filter(user => user.userID !== userToDelete));
        setSuccessMessage("User Deleted Successfully");
        setSuccessPopupVisible(true);
        setTimeout(() => {
          setSuccessPopupVisible(false);
        }, 3000);
      } else {
        setError(`Error: ${response.message}`);
        window.alert(setError);
      }
    } catch (error) {
      window.alert(error);
      console.error("Error deleting user:", error);
      setError(`An error occurred while trying to delete the user: ${(error as Error).message}`);
    } finally {
      setPopupOpen(false);
      setUserToDelete(null);
    }
  };

  const handleCancel = () => {
    setUserToDelete(null);
    setPopupOpen(false);
  };

  if (error) return <p>Error: {error}</p>;

  return (
    <div className="tab">
      <div className="form-container">
        <form onSubmit={handleAddUser} className="add-user-form">
          <div className="form-row">
            <label htmlFor="employeeID">Employee ID:</label>
            <input
              type="text"
              id="employeeID"
              name="emplId"
              value={employeeID}
              onChange={handleEmployeeIDChange}
              onBlur={handleEmployeeIDBlur}
              required
            />
            <label htmlFor="userName">User Name:</label>
            <input
              type="text"
              id="userName"
              name="userName"
              value={newUser.userName}
              readOnly
              required
            />
          </div>
          <div className="form-row">
            <label htmlFor="userID">UserID:</label>
            <input
              type="text"
              id="userID"
              name="userID"
              value={newUser.userID}
              onChange={handleInputChange}
              required
            />
            <label htmlFor="password">Password:</label>
            <input
              type="text"
              id="password"
              name="password"
              value={newUser.password}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="form-row">
            <label htmlFor="department">Department:</label>
            <input
              type="text"
              id="department"
              name="department"
              value={newUser.department}
              readOnly
              required
            />
            <label htmlFor="userRole">UserRole:</label>
            <select
              id="userRole"
              name="userRole"
              value={newUser.userRole}
              onChange={handleInputChange}
              required
            >
              <option value="">Select Role</option>
              <option value="CE">ENGINEER</option>
              <option value="CH">Manager</option>
            </select>
          </div>
          <br />
          <div className="submit-row">
            <input type="submit" className="submit" value="New Account" />
          </div>
        </form>
      </div>
      <br />
      <hr/>
      <br/>
      <div className="table">
      {loading?  (<Loading/>
        ) : (
        <table className="record">
          <thead>
            <tr>
              <th >Action</th>
              <th>UserName</th>
              <th>EmplyeeID</th>
              <th>Department</th>
              <th>UserRole</th>
            </tr>
          </thead>
          <tbody>
            {users.map(user => (
              <tr key={user.userID}>
                <td>
                  <a
                    className="delete"
                    onClick={() => handleDelete(user.userID)}
                    role="button"
                    aria-label={`Delete user ${user.userID}`}
                  >
                    Delete
                  </a>
                </td>
                <td>{user.userName}</td>
                <td>{user.userID}</td>
                <td>{user.department}</td>
                <td>{user.userRole}</td>
              </tr>
            ))}
          </tbody>
        </table>
        )}
      </div>
      <ConfirmationPopup
        isOpen={isPopupOpen}
        onConfirm={handleConfirm}
        onCancel={handleCancel}
        title="Confirm Deletion"
        message="Are you sure you want to delete this user?"
      />
      <SuccessPopup
        isVisible={isSuccessPopupVisible}
        onClose={() => setSuccessPopupVisible(false)}
        message={successMessage}
      />
    </div>
  );
};

export default User;
