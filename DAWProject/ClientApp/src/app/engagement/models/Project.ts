export class Project {
  id: string;
  name: string;
  beneficiary: string;
  budget: string;
  startDate: Date;
  endDate: Date;
}

export class ProjectAssignment {
  userId: string;
  projectId: string;
}
