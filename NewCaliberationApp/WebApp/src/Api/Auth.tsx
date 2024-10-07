import axios, { AxiosError, AxiosResponse } from 'axios';
import apiClient from './apiClient';
import {ErrorResponse,ForgotPasswordResponse,LoginResponse} from '../Models/AuthModels'

const handleAxiosError = (error: unknown): string => {
  if (axios.isAxiosError(error)) {
    const axiosError = error as AxiosError<ErrorResponse>;
    return axiosError.response?.data.message ?? 'An error occurred';
  } else {
    return 'An error occurred';
  }
};

export const loginUser = async (empId: string, password: string): Promise<LoginResponse> => {
  try {
    const response: AxiosResponse<LoginResponse> = await apiClient.post('common/login', { empId, password });
    const { data, message, statusCode } = response.data;

    //if (statusCode === 200) {
      return response.data;
    //   sessionStorage.setItem('empId', data.empId);
    //   sessionStorage.setItem('right', data.right);
    //   sessionStorage.setItem('empName', data.empName);
    //   sessionStorage.setItem('email',data.email)
    //   sessionStorage.setItem('checkListApprover',data.checkListApprover)
    //   sessionStorage.setItem('accessToken', data.accessToken);
    //   return statusCode;
    // } else if (statusCode === 400) {
    //   return statusCode;
    // } else {
    //   throw new Error(message || 'Login failed');
    // }
  } catch (error: unknown) {
    const errorMessage = handleAxiosError(error);
    throw new Error(errorMessage);
  }
};

export const ForgotPassword = async (empId: string, email: string): Promise<ForgotPasswordResponse> => {
  try {
    const response: AxiosResponse<ForgotPasswordResponse> = await apiClient.post('common/ForgotPassword', {}, { params: { empId, email }});
    return response.data;
  } catch (error: unknown) {
    const errorMessage = handleAxiosError(error);
    throw new Error(errorMessage);
  }
};

export const logoutUser = (): void => {
  sessionStorage.clear();
  window.location.href = '/';
};

export const getUserInfo = (): { empId: string | null; right: string | null; empName: string | null } => {
  return {
    empId: sessionStorage.getItem('empId'),
    right: sessionStorage.getItem('right'),
    empName: sessionStorage.getItem('empName'),
  };
};
