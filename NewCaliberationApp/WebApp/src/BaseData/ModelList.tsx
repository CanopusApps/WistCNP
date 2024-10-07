import React, { useEffect, useState } from "react";
import { GetCalCycle ,downloadCSV} from "../Api/GlobalApi";
import { DropDownModel } from "../Models/UserModels";
import { CalListAssetDDL, CalAtributeDDL, DeleteCalModel,GetCalModelByFilter,DownloadCalModelExcel ,AddOrUpdateCalModel} from '../Api/BaseData';
import {GetCalmodel } from '../Models/BaseDataModels';
import "./ModelList.css";

const ModelList: React.FC = () => {
  const [named, setNamed] = useState<string>("");
  const [cycle, setCycle] = useState<string>("");
  const [model, setModel] = useState<string>("");
  const [id, setId] = useState<string>("");
  const [brand,setBrand]=useState<string>("");
  const [department, setDepartment]=useState<string>("");
  const [attribute, setAttribute] = useState<string>("");
  const [calCycle, setCalCycle] = useState<DropDownModel[]>([]);
  const [name, setName] = useState<DropDownModel[]>([]);
  const [calAtribute, setCalAtribute] = useState<DropDownModel[]>([]);
  const [calModelList, setCalModelList] = useState<GetCalmodel[]>([]);
  const [calFilter, setCalFilter] = useState<number>(0);
  const [error, setError] = useState<string | null>(null);


  useEffect(() => {
    GetData();
  }, []);

  const GetData = async () => {
    try {
      const [cycleResponse, nameResponse, attrResponse] = await Promise.all([
        GetCalCycle(),
        CalListAssetDDL(),
        CalAtributeDDL(),
      ]);
      setCalCycle(cycleResponse.data);
      setName(nameResponse.data);
      setCalAtribute(attrResponse.data);
    } catch (error) {
      setError("Failed to load data");
    }
  };

  const handleCycleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setCycle(event.target.value);
  };

  const handleNameChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setNamed(event.target.value);
  };

  const handleModelChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setModel(event.target.value);
  };

  const handleDepartment = (event: React.ChangeEvent<HTMLInputElement>) => {
    setDepartment(event.target.value);
  }

  const handleBrand = (event: React.ChangeEvent<HTMLInputElement>) => {
    setBrand(event.target.value);
  } 

  const handleAttrChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setAttribute(event.target.value);
  };

  const GetCalModelLIst = async () => {
    let x = { filterId:calFilter, content: ""};
if(calFilter===1)
{
     x = { filterId:calFilter, content: model};
}
else if(calFilter===2)
{
  x = { filterId:calFilter, content: attribute};
}
    try {
      const response = await GetCalModelByFilter(x);
      if (response.statusCode === 200) {
        setCalModelList(response.data || []);
      }
    } catch (error) {
      setError("Failed to retrieve calibration models");
    }
  };

  const DownloadExcel = async() =>{
    const response = await DownloadCalModelExcel(calModelList);
    if(response.statusCode===200)
    {
      const data = response.data;
    downloadCSV(data?data:"","CalChickList");
    }
    else{
      alert(response.message);
    }
  }

  const HandleAddCalModel = async()=>
  {
    const values = {
      id:id,
      name:named,
      modelName:model,
      brand:brand,
      attribute:attribute,
      department:department,
      cycle:cycle,}
    const response = await AddOrUpdateCalModel(values);
    if(response.statusCode===200)
    {
      setId("");
      setNamed("");
      setModel("");
      setBrand("");
      setAttribute("");
      setDepartment("");
      setCycle("");
      alert(response.message);
    }
    else{
      alert(response.message);
    }
  }
  const HandleUpdate = (model: GetCalmodel) => {
    setNamed(model.name);
    setId(model.id);
    setAttribute(model.attribute);
    setBrand(model.brand);
    setCycle(model.cycle);
    setDepartment(model.department);
    setModel(model.modelName);
  }

  const HandleDelete=async(model: GetCalmodel)=>{
    const response = await DeleteCalModel(model.id);
    alert(response.message);
    GetData();
  }
  
  return (
    <div className="model-list-container">
      {error && <div className="error">{error}</div>}
      <form onSubmit={(e) => { e.preventDefault(); }}>
        <div className="form-group">
          <label>Name</label>
          <select className='calinput' value={named} onChange={handleNameChange} disabled={id !== ""} required>
            <option value="" disabled>Select an option</option>
            {name.map((item, index) => (
              <option key={index} value={item.data}>{item.data}</option>
            ))}
          </select>
          
          <label>Model</label>
          <input type="text" className="model-input" value ={model} onChange={handleModelChange} disabled={id !== ""}/>
        </div>
        <div className="form-group">
          <label>Brand</label>
          <input type="text" className="brand-input" value ={brand} onChange={handleBrand}/>
          
          <label>Attribute</label>
          <select className='calinput' value={attribute} onChange={handleAttrChange} required>
            <option value="" disabled>Select an option</option>
            {calAtribute.map((item, index) => (
              <option key={index} value={item.data}>{item.data}</option>
            ))}
          </select>
        </div>
        <div className="form-group">
          <label>Department</label>
          <input type="text" className="department-input" value={department} onChange={handleDepartment} />
          
          <label>Cycle</label>
          <select className='calinput' value={cycle} onChange={handleCycleChange} required>
            <option value="" disabled>Cycle Period</option>
            {calCycle.map((item, index) => (
              <option key={index} value={item.data}>{item.data}</option>
            ))}
          </select>
        </div>
        <div>
    <label>
      <input
        type="radio"
        value="1"
        checked={calFilter === 1}
        onChange={(e) => setCalFilter(parseInt(e.target.value))}
      />
      ByModel
    </label>
    <label>
      <input
        type="radio"
        value="2"
        checked={calFilter === 2}
        onChange={(e) => setCalFilter(parseInt(e.target.value))}
      />
      ByAttribute
    </label>
    <label>
      <input
        type="radio"
        value="0"
        checked={calFilter === 0}
        onChange={(e) => setCalFilter(parseInt(e.target.value))}
      />
      GetAll
    </label>
  </div>
        <div className="button-group">
        <input type="submit" value={id === "" ? "New" : "Update"} onClick={HandleAddCalModel}/>

          <button type="button" onClick={GetCalModelLIst}>Query</button>
          {calModelList.length>0?
          (<button type="button" onClick={DownloadExcel}>Export To Excel</button>):(<br/>)}
        </div>
      </form>
      <hr />
      {calModelList.length <= 0? (<div></div>) :
      (<div>
      <div className="table">
            <table className="record">
          <thead>
            <tr>
              <th>Update</th>
              <th>Delete</th>
              <th>Model</th>
              <th>Name</th>
              <th>Brand</th>
              <th>Attribute</th>
              <th>Calibration cycle(M)</th>
              <th>Department</th>
              <th>UserID</th>
              <th>LogDate</th>
            </tr>
          </thead>
          <tbody>
            {calModelList.map((model, index) => (
              <tr key={index}>
                <td><button className ="cbtns" onClick={()=>HandleUpdate(model)}>Update</button></td>
                <td><button className ="cbtn" onClick={()=>HandleDelete(model)}>Delete</button></td>
                <td>{model.modelName}</td>
                <td>{model.name}</td>
                <td>{model.brand}</td>
                <td>{model.attribute}</td>
                <td>{model.cycle}</td>
                <td>{model.department}</td>
                <td>{model.userID}</td>
                <td>{model.logDate}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>)}
    </div>
  );
};

export default ModelList;
