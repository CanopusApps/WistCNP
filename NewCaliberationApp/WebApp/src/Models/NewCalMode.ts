export interface CalibrationData {
  id:string;
  assetTag: string;
  model: string;
  brand: string;
  serialNo: string;
  userDept: string;
  lastCalDate: string;
  attribute: string;
  name: string;
  calPeriod: string;
  userPic: string;
  keeper: string;
  nextCalDate: string;
  calType: string;
  plantId: string;
  project: string;
  calDept: string;
  email: string;
  oldAssetTag: string;
  calStatus: string;
  cALCertificationNo: string;
  remark: string;
}

export const defaultCalibrationData: CalibrationData = {
  id:'',
  assetTag: '',
  model: '',
  brand: '',
  serialNo: '',
  userDept: '',
  lastCalDate: "",
  attribute: '',
  name: '',
  calPeriod: '',
  userPic: '',
  keeper: '',
  nextCalDate: "",
  calType: '',
  plantId: '',
  project: '',
  calDept: '',
  email: '',
  oldAssetTag: '',
  calStatus: '',
  cALCertificationNo: '',
  remark: '',
};



export interface Modeldetails {
  name: string;
  brand: string;
  calPeriod: string;
  calDept: string;
  nextCalDate: string;  
  lastCalDate: string;  
  attribute: string;
}
