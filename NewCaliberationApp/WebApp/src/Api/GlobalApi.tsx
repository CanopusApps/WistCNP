import apiClient from './apiClient';
import{ServiceResponses,DropDownModel} from '../Models/UserModels';
import {UserListResponse,ApiResponse,UserType,ApiResponses, ServiceResponse} from '../Models/UserModels'
import { Axios, AxiosResponse } from 'axios';

export const GetCalCycle =async() : Promise<ServiceResponses<DropDownModel[]>>=>
    {
      try{
      const response:AxiosResponse<ServiceResponses<DropDownModel[]>>= await apiClient.get('DynamicData/GetCalCycleOrPlant?isPlant=false');
     
      return response.data;
      }
      catch(error:any){
        console.error('Error:', error.response ? error.response.data : error.message);
        throw new Error(error.response ? error.response.data.message : 'Request failed');
      }
    };

export const downloadCSV = (base64String: string, filename: string) => {
    const decodedData = atob(base64String);
    const blob = new Blob([decodedData], { type: 'text/csv' });
    const link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = filename;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};

export const formatDate = (date: Date | string): string => {
    const dateObj = typeof date === 'string' ? new Date(date) : date;
    const year = dateObj.getFullYear();
    const month = (dateObj.getMonth() + 1).toString().padStart(2, '0'); 
    const day = dateObj.getDate().toString().padStart(2, '0');
    return `${year}-${month}-${day}`;
  };

