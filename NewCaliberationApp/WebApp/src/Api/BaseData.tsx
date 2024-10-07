import apiClient from './apiClient';
import { Axios, AxiosResponse } from 'axios';
import {UserListResponse,ApiResponse,UserType,ApiResponses, ServiceResponse,ServiceResponses, DropDownModel} from '../Models/UserModels';
import { CalListModel ,CalListFilterModel,AddCalListModel,CalApprove,CalModelModel,GetCalmodel,CalModelFiltermodel} from '../Models/BaseDataModels';

export const UserList = async (): Promise<ApiResponse<UserListResponse[]>> => {
  try {
      const response: AxiosResponse<ApiResponse<UserListResponse[]>> = await apiClient.post('BaseData/GetCalUser', {});

      return response.data;
  } catch (error: any) {
      throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
};

export const DeleteUse = async (EmplId: string): Promise<ApiResponses> => {
  try {
    const response: AxiosResponse<ApiResponses> = await apiClient.post('BaseData/DeleteUsers', { EmplId });
    console.log(response);
    return response.data; 
  } catch (error: any) {
    console.error('Error:', error.response ? error.response.data : error.message);
    throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
};


export const GetHrAtUser = async (emplId: string): Promise<ApiResponse<UserType>> => {
    try {
        const response: AxiosResponse<ApiResponse<UserType>> = await apiClient.post('BaseData/HrAtData', { emplId });
        return response.data; 
    } catch (error: any) {
        console.error('Error:', error.response ? error.response.data : error.message);
        throw new Error(error.response ? error.response.data.message : 'Request failed');
    }
};

export const AddUser = async (user: any): Promise<ApiResponse<any>> => {
    try {
        const response: AxiosResponse<ApiResponse<any>> = await apiClient.post('BaseData/AddCalUsers', user);
        return response.data; 
    } catch (error: any) {
        console.error('Error:', error.response ? error.response.data : error.message);
        throw new Error(error.response ? error.response.data.message : 'Request failed');
    }
};

export const AddOrUpdateCalCheckList=async (data :AddCalListModel) : Promise<ApiResponses>=>
{
  try{
    const response :AxiosResponse<ApiResponses> = await apiClient.post('CalCheckList/AddOrUpdateCalCheckList',data);
    return response.data;
  }
  catch (error: any) {
    console.error('Error:', error.response ? error.response.data : error.message);
    throw new Error(error.response ? error.response.data.message : 'Request failed');
}
};

export const GetCalCheckList = async (data:CalListFilterModel,isCalOff : boolean): Promise<ServiceResponses<CalListModel[]>> =>{
  try{
    if(isCalOff === false)
    {
    const response:AxiosResponse<ServiceResponses<CalListModel[]>> = await apiClient.post('CalCheckList/GetAllCheckList?isCalOff=false',data);
    return response.data;
    }
    else{
      const response:AxiosResponse<ServiceResponses<CalListModel[]>> = await apiClient.post('CalCheckList/GetAllCheckList?isCalOff=true',data);
    return response.data;
    }
  }
  catch(error:any){
    console.error('Error:', error.response ? error.response.data : error.message);
    throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
};



export const DeleteeUse = async (EmplId: string): Promise<ApiResponses> => {
  try {
    const response: AxiosResponse<ApiResponses> = await apiClient.post('BaseData/DeleteUsers', { EmplId });
    //console.log(response);
    return response.data; 
  } catch (error: any) {
    console.error('Error:', error.response ? error.response.data : error.message);
    throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
};

export const ExcelDownload = async (data : CalListModel[]): Promise<ServiceResponse<string>> =>{
try{
  const response : AxiosResponse<ServiceResponse<string>> = await apiClient.post('CalCheckList/GenerateCsv',{data});
  console.table(response.data.data);
  return response.data;
}
catch(error: any)
{
  console.error('Error:', error.response ? error.response.data : error.message);
  throw new Error(error.response ? error.response.data.message : 'Request failed');
}
};

export const DeleteCalList =async(id: string):Promise<ApiResponses> =>
{
  try{
    const response:AxiosResponse<ApiResponses>=await apiClient.post('CalCheckList/DeleteCalListdata',{id});
    console.log(response);
    return response.data; 
  }
   catch (error: any) 
  {
    console.error('Error:', error.response ? error.response.data : error.message);
    throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
}

export const ApproveOrRejectCalSignOff = async(data:CalApprove) :Promise<ApiResponses>=>{
try{
  const response : AxiosResponse<ApiResponses> =await apiClient.post('CalCheckList/RejectOrApproveCalCheckList',data);
  console.log(response);
  return response.data; 
}
 catch (error: any) 
{
  console.error('Error:', error.response ? error.response.data : error.message);
  throw new Error(error.response ? error.response.data.message : 'Request failed');
}
};

export const CalListAssetDDL = async():Promise<ServiceResponses<DropDownModel[]>>=>{
  try{
    const response : AxiosResponse<ServiceResponses<DropDownModel[]>> = await apiClient.get('CalModel/CalListAssetDDL');
    console.log(response);
    return response.data;
  }
  catch (error: any) 
  {
    console.error('Error:', error.response ? error.response.data : error.message);
    throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
};

export const CalAtributeDDL = async():Promise<ServiceResponses<DropDownModel[]>>=>{
  try{
    const response : AxiosResponse<ServiceResponses<DropDownModel[]>> = await apiClient.get('CalModel/CalAtrributeDDL');
    console.log(response);
    return response.data;
  }
  catch (error: any) 
  {
    console.error('Error:', error.response ? error.response.data : error.message);
    throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
};

export const GetCalModelByFilter = async(data:CalModelFiltermodel) :Promise<ServiceResponse<GetCalmodel[]>>=>{
  try{
    const response :AxiosResponse<ServiceResponse<GetCalmodel[]>>= await apiClient.post('CalModel/GetCalModel',data);
    return response.data;
  }
  catch(error : any)
  {
    console.error('Error:', error.response ? error.response.data : error.message);
    throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
};

export const DownloadCalModelExcel = async(data : GetCalmodel[]) :Promise<ServiceResponse<string>> =>{
  try{
    const response : AxiosResponse<ServiceResponse<string>> = await apiClient.post('CalModel/GenerateCalModelCsv',{data});
    return (response.data);
  }
  catch(error : any)
  {
    console.error('Error:', error.response ? error.response.data : error.message);
    throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
};

export const AddOrUpdateCalModel = async(data :CalModelModel) :Promise<ApiResponses>=>{
  try{
    const response : AxiosResponse<ApiResponses> = await apiClient.post('CalModel/AddorUpdateCalModel',data);
    return response.data;
  } catch(error : any)
  {
    console.error('Error:', error.response ? error.response.data : error.message);
    throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
};

export const DeleteCalModel = async(id:string) :Promise<ApiResponses>=>{
  try{
    const response : AxiosResponse<ApiResponses> =await apiClient.post('CalModel/DeleteCalModel',{id});
    return(response.data);
  } catch(error:any)
  {
    console.error('Error:', error.response ? error.response.data : error.message);
    throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
}
