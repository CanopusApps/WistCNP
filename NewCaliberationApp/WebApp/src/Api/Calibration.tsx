import apiClient from './apiClient';
import { Axios, AxiosResponse } from 'axios';
import {Modeldetails,CalibrationData} from '../Models/NewCalMode';
import {UserListResponse,ApiResponse,UserType,ApiResponses, ServiceResponse,ServiceResponses, DropDownModel} from '../Models/UserModels';

export const GetModelDdl = async():Promise<ServiceResponses<DropDownModel[]>> =>{
    try{
        const response :AxiosResponse<ServiceResponses<DropDownModel[]>> = await apiClient.get('NewCalibration/ModelDDL');
        return response.data;
    }
    catch(error : any)
    {
        throw new Error(error.response ? error.response.data.message : 'Request failed');
    }
};

export const GetPlantDdl = async():Promise<ServiceResponses<DropDownModel[]>> =>{
    try{
        const response :AxiosResponse<ServiceResponses<DropDownModel[]>> = await apiClient.get(`DynamicData/GetCalCycleOrPlant?isPlant=true`);
       return response.data;
    }
    catch(error : any)
    {
        throw new Error(error.response ? error.response.data.message : 'Request failed');
    }
};

export const GetProjectDdl = async(plant :string):Promise<ServiceResponses<DropDownModel[]>> =>{
    try{
        const response: AxiosResponse<ServiceResponses<DropDownModel[]>> = await apiClient.get(`DynamicData/GetProject?plant=${plant}`);
        return response.data;
    }
    catch(error : any)
    {
        throw new Error(error.response ? error.response.data.message : 'Request failed');
    }
};

export const GetCalModelDetail = async (name: string): Promise<ServiceResponse<Modeldetails>> => {
    try {
        const response: AxiosResponse<ServiceResponse<Modeldetails>> = await apiClient.get(`NewCalibration/GetCalModelDetail?name=${name}`);
        return response.data;
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || 'Request failed';
        throw new Error(`GetCalModelDetail error: ${errorMessage}`);
    }
};

export const GetCalDetailsByAssetTag = async (name: string): Promise<ServiceResponse<CalibrationData>> => {
    try {
        const response: AxiosResponse<ServiceResponse<CalibrationData>> = await apiClient.post(`NewCalibration/GetCalListById?assetTag=${name}`);
        return response.data;
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || 'Request failed';
        throw new Error(`GetCalModelDetail error: ${errorMessage}`);
    }
};

export const CreateCalibration = async (data: CalibrationData): Promise<ServiceResponse<CalibrationData>> => {
    try {
        const response: AxiosResponse<ServiceResponse<CalibrationData>> = await apiClient.post(`NewCalibration/AddorUpdateNewCalibration`,data);
        return response.data;
    } catch (error: any) {
        const errorMessage = error.response?.data?.message || 'Request failed';
        throw new Error(`GetCalModelDetail error: ${errorMessage}`);
    }
};



