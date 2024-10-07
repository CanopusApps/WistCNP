export interface LoginResponseData {
    empId: string;
    right: string;
    empName: string;
    checkListApprover:string;
    email:string;
    accessToken: string;
  };
  
  export interface LoginResponse {
    data: LoginResponseData;
    message?: string;
    statusCode: number;
  };
  
  export interface ForgotPasswordResponse {
    message?: string;
    statusCode: number;
  };
  
  export interface ErrorResponse {
    message: string;
  };
  