
export interface MachineData {
    pmDurationHrs: string;
    actualPmDate: string | null;
    pmAdherence: string;
    currentPmStatus: boolean;
    pmManager: string;
    engineeringManager: string;
    dccCheckListLink: string;
    toolList: string;
    machineIdSn: string;
    machineName: string;
    isCheck :boolean;
    lastCheck:string;
    project: string;
    line: string;
    subLine: string;
    machineLocation: string;
    make: string;
    checklistNo: string;
    machineCategory: string;
    tataDRIName: string;
    vendorDRI: string;
    firstTimePmScheduleDate: string;
    frequency: string;
  };


  export interface PmScheduleModel
  {
      firstTimePmSchedule?: Date | null;
      secondTimePmSchedule?: Date | null;
      thirdTimePmSchedule?: Date | null;
      fourthTimePmSchedule?: Date | null;
      fifthTimePmSchedule?: Date | null;
      sixthTimePmSchedule?: Date | null;
      seventhTimePmSchedule?: Date | null;
      eighthTimePmSchedule?: Date | null;
      ninthTimePmSchedule?: Date | null; 
      tenthTimePmSchedule?: Date | null;
      eleventhTimePmSchedule?: Date | null;
      twelfthTimePmSchedule?: Date | null;
  };

  export interface ScheduleModel extends PmScheduleModel
  {
    machineIdSn: string;
    requiredCriticalSparePartList: string;
    headCountSize: string;
    plantHead: string;
    pmScheduleFlow: string;
    threeDaysAlert?: Date;  
    oneDayAlert?: Date;
    oneDayAfter?: Date;
    twoDaysAfter?: Date;
    threeDaysAfter?: Date;
    pmWorkFlow: string;
    month?: string;
    modified?: Date;
    created?: Date;
    createdBy: string;
    modifiedBy: string;
};
  

