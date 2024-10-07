export interface ApiResponse<T> {
  statusCode: number;
  message?: string;
  data: T;
}
export interface ApiResponses {
  statusCode: number;
  message?: string;
}
export class ServiceResponse<T> {
  public data: T | null;
  public message: string;
  public statusCode: number;

  constructor(statusCode: number, message: string, data: T | null) {
      this.statusCode = statusCode;
      this.message = message;
      this.data = data;
  }
}


export interface UserListResponse
{
        userName: string;
        userID: string;
        department: string;
        userRole : string;
}

export interface UserType
{
    userName: string;
    userID: string;
    department: string;
    userRole: string;
    emplId: string;
    password: string;
}
export interface ServiceResponses<T> {
  statusCode: number;
  message: string;
  data: T;
  totalCount: number;
  pageNumber: number;
  pageSize: number;
}

export interface DropDownModel
{
    id	:string,
    data:	string
};