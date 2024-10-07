export interface CalListModel
{
    id : string,
    name:	string,
    approver:string,
    cycle	:string,
    pubDate : string,
    criteria:	string,
    status	:number,
    remarks	:string,
    serialNo:	string,
    comments	:string
};
export interface AddCalListModel
{
    id : string,
    name:	string,
    approver:string,
    cycle	:string,
    pubDate : string,
    criteria:	string,
    status	:number,
    remarks	:string,
};
export interface CalListFilterModel
{
    pageNumber : number ,
    pageSize	:number,
    searchName	: string,
    calCycle	:string,
    criteria	:string,
    status	:string,
    pubDate:	string
};
export const initialCalFilter: CalListFilterModel = {
    pageNumber: 1,
    pageSize: 10,
    searchName: '',
    calCycle: '',
    criteria: '',
    status: '',
    pubDate: ''
  };


export interface CalApprove
{
    id : string[],
    isApprove : boolean,
    comment :string
};

export const calReject : CalApprove = 
{
    id:[],
    isApprove:true,
    comment:""
};

export const calmodel :GetCalmodel =
{
    id:"",
    name:"",
    modelName:"",
    brand:"",
    attribute:"",
    department:"",
    cycle:"",
    logDate :"",
    userID :""
}

export interface CalModelModel 
{
    id	:string,
    name:string,
    modelName:string,
    brand:string,
    attribute:string,
    department:string,
    cycle:string,
    
}

export interface GetCalmodel extends  CalModelModel
{
    logDate :string,
    userID :string
}

export interface CalModelFiltermodel
{
    filterId:number,
    content:string
}