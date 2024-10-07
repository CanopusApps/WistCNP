import apiClient from './apiClient';
import { AxiosResponse } from 'axios';
import {ApiResponses,ServiceResponse,ServiceResponses} from '../Models/UserModels';
import {MachineData,ScheduleModel} from "../Models/PmModels";
import ConfirmationPopup from "../Common/ConfirmationPopup"

export const PMAddExcel = async (file :File): Promise<ApiResponses> => {
    const formData = new FormData();
  formData.append('file', file);
    try {
     const response: AxiosResponse<ApiResponses> = await apiClient.post('PmMachine/UploadExcel', formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      }); 
     console.log(response);
      return response.data; 
    } catch (error: any) {
      console.error('Error:', error.response ? error.response.data : error.message);
      throw new Error(error.response ? error.response.data.message : 'Request failed');
    }
  };

  export const AddPMMachine = async (data: MachineData): Promise<ApiResponses> => {
    try {
        const response: AxiosResponse<ApiResponses> = await apiClient.post('PmMachine/AddPmDetailsAdd', data,{params:{isAuto:true}});
  
        return response.data;
    } catch (error: any) {
        throw new Error(error.response ? error.response.data.message : 'Request failed');
    }
  };


  // export const PmGetAll = async() : Promise<ServiceResponse<MachineData[]>> =>{
  //   try {
  //       const response: AxiosResponse<ServiceResponse<MachineData[]>> = await apiClient.get('PmMachine/GetPmdeatilsAll', {});
  //       console.log(response.data.data);
  //       return response.data;
  //   } catch (error: any) {
  //       throw new Error(error.response ? error.response.data.message : 'Request failed');
  //   }
  // };

  export const PmGetAll = async (searchTerm: string, pageNumber: number, pageSize: number): Promise<ServiceResponses<MachineData[]>> => {
    try {
        const response: AxiosResponse<ServiceResponses<MachineData[]>> = await apiClient.get('PmMachine/GetPmdeatilsAll', {
            params: {
                searchTerm,
                pageNumber,
                pageSize,
            },
        });

        console.log(response.data.data);

        return response.data;
    } catch (error: any) {
            throw new Error(error.response?.data.message || 'Request failed');
    }
};

  export const PmItemDelete = async(machineIdSn : string) : Promise<ApiResponses> =>{
    try {
      const response : AxiosResponse<ApiResponses> =await apiClient.post('PmMachine/DeletePM', {machineIdSn});
      return response.data;
    }
    catch (error: any) {
      throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
  };

  export const GetPmScheduleDataById = async(machineIdSn : string) :Promise<ServiceResponse<ScheduleModel>>=>
  {
    try {
      const response: AxiosResponse<ServiceResponse<ScheduleModel>> = await apiClient.post('PmMachine/GetScheduleList', {machineIdSn});
      return response.data;
  } catch (error: any) {
      throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
  };

  export const UpdatePmScheduleData = async (machineId: string, data: ScheduleModel): Promise<ServiceResponse<string>> => {
   try{
   const response: AxiosResponse<ServiceResponse<string>>  = await apiClient.post(`PmMachine/UpdatePmSchedule`, data,{params:{machineId}});
    return response.data;
  } catch (error: any) {
    throw new Error(error.response ? error.response.data.message : 'Request failed');
  }
  };

  export const updateMachineCheck = async ( machineId: string, checkDate: Date ): Promise<ApiResponses> => {
    try {
      const url = `PmMachine/IsCheckedPmMachine`;
      const params = new URLSearchParams({ machineId,checkDate: checkDate.toISOString()}).toString(); 
      const response: AxiosResponse<ApiResponses> = await apiClient.post(`${url}?${params}`);
  
      return response.data;
    } catch (error: any) {
      throw new Error(error.response ? error.response.data.message : 'Request failed');
    }
  };

