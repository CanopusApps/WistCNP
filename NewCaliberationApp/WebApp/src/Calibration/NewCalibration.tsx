import React, { useState, ChangeEvent, FormEvent, useEffect } from "react";
import { CalibrationData, defaultCalibrationData, Modeldetails } from "../Models/NewCalMode"; 
import { GetModelDdl,GetPlantDdl,  GetProjectDdl,  GetCalModelDetail, GetCalDetailsByAssetTag, CreateCalibration } from "../Api/Calibration";
import styles from "./NewCalibration.module.css"; 
import { DropDownModel } from '../Models/UserModels';

const Calibration: React.FC = () => {
  const [formData, setFormData] = useState<CalibrationData>(defaultCalibrationData);
  const [modelDdl, setModelDdl] = useState<DropDownModel[]>([]);
  const [plantDdl, setPlantDdl] = useState<DropDownModel[]>([]);
  const [projectDdl, setProjectDdl] = useState<DropDownModel[]>([]);
  const [calStatus,setCalStatus] =useState<string>("")
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);
  const [serialNo,setSerialNo] =useState<string>("")
  const [assetTag, setAssetTag] = useState<string>("");
  const [model, setModel] = useState<string>("");
  const [plant, setPlant] = useState<string>("");
  const [project, setProject] = useState<string>("");
  const [plantName,setPlantName] = useState<string>("");
  const [nextDate, setNextDate] = useState<string>("");
  const [lastDate, setLastDate] = useState<string>("");
  const [calPeriod, setCalPeriod] = useState<string>("Set CalPeriod");
  const [name, setName] = useState<string>("");
  const [attribute, setAttribute] = useState<string>("");
  const [cALCertification, setCAlCertification] = useState<string>("");
  const [brand, setBrand] = useState<string>("");
  const [calDept, setCalDept] = useState<string>("");
  const [isPlant,setIsPlant] = useState<boolean>(true);

  useEffect(() => {
    const fetchModelData = async () => {
      setLoading(true);
      try {
        const [modelResponse, plantsResponse] = await Promise.all([
          GetModelDdl(),
          GetPlantDdl()
        ]);
        setModelDdl(modelResponse.data);
        setPlantDdl(plantsResponse.data);
      } catch (err) {
        setError("Failed to fetch model data: " + (err as Error).message);
      } finally {
        setLoading(false);
      }
    };
    fetchModelData();
  }, []);

  const handleProjectChange = async (selectedPlantId: string ,plant :string) => {
    setPlant(selectedPlantId);
    setPlantName(plant);
    try {
      const value = await GetProjectDdl(selectedPlantId);
      if (value.statusCode === 400) {
        alert("Under this plant, no projects are created");
        setProjectDdl([]);
        setIsPlant(true);
      }
      else{
      setProjectDdl(value.data || []);
      setIsPlant(false);
      }
    } catch (err) {
      setError("Failed to fetch projects: " + (err as Error).message);
    }
  };
  

  const handleProjectSetChange = (event: ChangeEvent<HTMLSelectElement>) => {
    setProject(event.target.value);
  };

  const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData(prevData => ({ ...prevData, [name]: value }));
  };

  const validateForm = (): boolean => {
    if (!assetTag || !model) {
      setError("Asset Tag and Model are required.");
      return false;
    }
    return true;
  };

  const handleSubmit = async (e: FormEvent) => {
    e.preventDefault();
    if (!validateForm()) return;

    const calibrationData = {
      ...formData,
      assetTag,
      brand,
      model,
      calPeriod,
      nextCalDate: nextDate,
      lastCalDate: lastDate,
      attribute,
      plantId:plant,
      project:project,
      calDept:calDept,
      name,
      plant:plantName,
      serialNo,
      calStatus,
      cALCertificationNo: cALCertification,
    };

    setLoading(true);
    try {
      const response = await CreateCalibration(calibrationData);
      console.log('Calibration created:', response);
      alert(response.message);
      setError(null);
    } catch (err) {
      setError(`Failed to create calibration: ${(err as Error).message}`);
    } finally {
      setFormData (defaultCalibrationData);
      setCalStatus("");
      setError("");
      setSerialNo("");
      setAssetTag("");
      setModel("");
      setPlant("");
      setProject("");
      setPlantName("");
      setNextDate("");
      setCalDept("");
      setLastDate("");
      setAssetTag("");
      setLoading(false);
      setCalPeriod("");
      setName("");
      setAttribute("");
      setBrand("");
      setCAlCertification(""); 

    }
   
  };
  const handleCancel =()=>
  {
    setFormData (defaultCalibrationData);
    setCalStatus("");
    setError("");
    setSerialNo("");
    setAssetTag("");
    setModel("");
    setPlant("");
    setProject("");
    setPlantName("");
    setNextDate("");
    setCalDept("");
    setLastDate("");
    setAssetTag("");
    setLoading(false);
    setCalPeriod("");
    setName("");
    setAttribute("");
    setBrand("");
    setCAlCertification(""); 
  }

  const handleModelChange = async (event: ChangeEvent<HTMLSelectElement>) => {
    const selectedModel = event.target.value;
    setError(null);
    setModel(selectedModel);
    await fetchModelDetails(selectedModel);
  };

  const fetchModelDetails = async (modelName: string) => {
    setLoading(true);
    try {
      const response = await GetCalModelDetail(modelName);
      const data = response.data;
      setCalPeriod(data?.calPeriod || "Set CalPeriod");
      setNextDate(data?.nextCalDate || "");
      setLastDate(data?.lastCalDate || "");
      setName(data?.name || "");
      setAttribute(data?.attribute || "");
      setBrand(data?.brand || "");
      setCalDept(data?.calDept || "");
    } catch {
      setError("Failed to fetch model details.");
    } finally {
      setLoading(false);
    }
  };

  const handleChangeSetNextDate = (event: ChangeEvent<HTMLInputElement>) => {
    const dateString = event.target.value;
    setLastDate(dateString);

    const date = new Date(dateString);
    if (isNaN(date.getTime())) {
      setError("Invalid date");
      return;
    }
    if (calPeriod === "Set CalPeriod") {
      alert("Calibration period not set.");
      return;
    }

    const daysToAdd = parseDuration(calPeriod);
    const nextDate = new Date(date);
    nextDate.setDate(date.getDate() + daysToAdd);
    setNextDate(nextDate.toISOString().split('T')[0]);
  };

  const parseDuration = (duration: string): number => {
    const regex = /(\d+)\s*(week|month|year)s?/i;
    const match = duration.match(regex);
    if (!match) throw new Error("Invalid duration format");

    const value = parseInt(match[1], 10);
    const unit = match[2].toLowerCase();

    switch (unit) {
      case 'week':
        return value * 7;
      case 'month':
        return value * 30;
      case 'year':
        return value * 365;
      default:
        throw new Error("Invalid duration format");
    }
  };

  const handleGetDetailsAssetTag = (event: ChangeEvent<HTMLInputElement>) => {
    setAssetTag(event.target.value);
    setError(null);
  };

  const handleGetDetail = async () => {
    setLoading(true);
    try {
      if(assetTag==="")
      {
        alert("Asset Tag Required");
        return;
      }
      const response = await GetCalDetailsByAssetTag(assetTag);
      if (response.statusCode === 400) {
        alert("Asset Tag not exsist");
        return;
      }

      const data: CalibrationData = response.data || defaultCalibrationData;
      setFormData(data);
      setLastDate(formatDate(data.lastCalDate));
      setNextDate(formatDate(data.nextCalDate));
      setCalPeriod(data.calPeriod || "Set CalPeriod");
      setModel(data.model || '');
      setName(data.name || '');
      setBrand(data.brand || '');
      setAttribute(data.attribute || '');
      setCAlCertification(data.cALCertificationNo || '');
      setPlant(data.plantId||'');
      setSerialNo(data.serialNo);
      setCalStatus (data.calStatus);
      setCalDept(data.calDept || "");
    } catch {
      setError('Failed to fetch asset tag details.');
    } finally {
      setLoading(false);
    }
  };

  const formatDate = (dateString: string): string => {
    const parts = dateString.split('/');
    return parts.length === 3 ? `${parts[0]}-${parts[1]}-${parts[2]}` : dateString;
  };

  return (
    <div className={styles.App}>
      <form onSubmit={handleSubmit}>
        {error && <div className={styles.error}>{error}</div>}
        {loading && <div className={styles.loading}></div>}

        <div className={styles.row}>
          <label className={styles.label}>
            Asset Tag:
            <input 
              type="text" 
              name="assetTag" 
              className={styles.assetag} 
              onChange={handleGetDetailsAssetTag}
              value={assetTag}
            />
          </label>
        </div>

        <div className={styles.row}>
          <label className={styles.label}>
            Model:
            <select name="model" value={model} onChange={handleModelChange} className={styles.select}>
              <option value="">Select Model</option>
              {modelDdl.map((item, index) => (
                <option key={index} value={item.data}>{item.data}</option>
              ))}
            </select>
          </label>
          <label className={styles.label}>
            Name:
            <input 
              type="text" 
              name="name" 
              value={name} 
              disabled
              className={styles.input} 
            />
          </label>
          <label className={styles.label}>
            Brand:
            <input 
              type="text" 
              name="brand" 
              value={brand} 
              disabled
              className={styles.input} 
            />
          </label>
          <label className={styles.label}>
            Serial No:
            <input 
              type="text" 
              name="serialNo" 
              value={serialNo} 
              onChange={(e) => setSerialNo(e.target.value)}
              className={styles.input} 
            />
          </label>
        </div>

        <div className={styles.row}>
        <label className={styles.label} htmlFor="plantId">
             Plant ID:
            <select
              id="plantId"
              name="plantId"
              value ={plant}
              onChange={(e) => {
                const selectedId = plantDdl.find(item => item.data === e.target.value)?.id;
                const plants = e.target.value;
                if (selectedId) {
                handleProjectChange(selectedId,plants); 
                setPlant(e.target.value);
                }
              }}
              className={styles.select}
            >
              <option value="">Select Plant</option>
              {plantDdl.map((item, index) => (
                <option key={index} value={item.data}>
                  {item.data}
                </option>
              ))}
            </select>
          </label>
          <label className={styles.label}>
            Project:
            <select
      name="project"
      value={project}
      onChange={handleProjectSetChange}
      className={styles.select}
      disabled={isPlant}
    > 
      <option value="">Select Project</option>
      {projectDdl.map((item, index) => (
        <option key={index} value={item.data}>
          {item.data}
        </option>
      ))}
    </select>
          </label>
          <label className={styles.label}>
            CAL Dept:
            <input 
              type="text" 
              name="calDept" 
              value={calDept} 
              onChange={handleChange} 
              className={styles.input} 
              disabled
            />
          </label>
          <label className={styles.label}>
            User Dept:
            <input 
              type="text" 
              name="userDept" 
              value={formData.userDept} 
              onChange={handleChange} 
              className={styles.input} 
            />
          </label>
        </div>

        <div className={styles.row}>
          <label className={styles.label}>
            Cal Period:
            <input 
              type="text" 
              name="CalPeriod" 
              value={calPeriod} 
              onChange={handleChange} 
              className={styles.input} 
              disabled
            />
          </label>
          <label className={styles.label}>
            User PIC:
            <input 
              type="text" 
              name="userPic" 
              value={formData.userPic} 
              onChange={handleChange} 
              className={styles.input} 
            />
          </label>
          <label className={styles.label}>
            Keeper:
            <input 
              type="text" 
              name="keeper" 
              value={formData.keeper} 
              onChange={handleChange} 
              className={styles.input} 
            />
          </label>
        </div>

        <div className={styles.row}>
          <label className={styles.label}>
            {formData.id === "" ? "Start CAL Date:" : "Last CAL Date:"}
            <input
              type="date"
              name="lastCALDate"
              value={lastDate}
              onChange={handleChangeSetNextDate}
              className={styles.input}
            />
          </label>
          <label className={styles.label}>
            Next CAL Date:
            <input
              type="date"
              name="nextCALDate"
              value={nextDate}
              readOnly
              className={styles.input}
            />
          </label>
          <label className={styles.label}>
            CAL Type:
            <select name="calType" value={formData.calType} onChange={handleChange} className={styles.select}>
              <option value="">Select CAL Type</option>
              <option value="Type1">Type1</option>
              <option value="Type2">Type2</option>
              <option value="Type3">Type3</option>
            </select>
          </label>
          <label className={styles.label}>
            Email:
            <input 
              type="email" 
              name="email" 
              value={formData.email} 
              onChange={handleChange} 
              className={styles.input} 
            />
          </label>
        </div>

        <div className={styles.row}>
          <label className={styles.label}>
            Old Asset Tag:
            <input 
              type="text" 
              name="oldAssetTag" 
              value={formData.oldAssetTag} 
              onChange={handleChange} 
              className={styles.input} 
            />
          </label>
          <label htmlFor="calStatus" className={styles.label}>
            CAL Status:
            <select
              id="calStatus"
              name="calStatus"
              value={calStatus}
              onChange={(e) => setCalStatus(e.target.value)}
              className={styles.select}
            >
              <option value="" disabled>Select CAL Status</option>
              <option value={1}>OK</option>
              <option value={2}>NG</option>
              <option value={6}>Waiting Cal</option>
            </select>
          </label>

          <label className={styles.label}>
            Attribute:
            <input 
              type="text" 
              name="attribute" 
              value={attribute} 
              disabled
              className={styles.input} 
            />
          </label>
        </div>

        <div className={styles.row}>
          <label className={styles.label}>
            CAL Certification No.:
            <input 
              type="text" 
              name="cAlCertification" 
              value={cALCertification} 
              onChange={(e) => setCAlCertification(e.target.value)} 
              className={styles.input} 
            />
          </label>
          <label className={styles.label}>
            Remark:
            <input 
              type="text" 
              name="remark" 
              value={formData.remark} 
              onChange={handleChange} 
              className={styles.input} 
            />
          </label>
        </div>

        <div style={{ marginTop: '20px', marginBottom: '20px' }}>
          <button type="submit" className={styles.button}>
            {formData.id === "" ? "Add New" : "Update"}
          </button>
          <button type="button" className={styles.button} onClick={handleGetDetail}>Query</button>
          <button type="button" className={styles.button} onClick={handleCancel}>Clear</button>
        </div>
      </form>
    </div>
  );
};

export default Calibration;
