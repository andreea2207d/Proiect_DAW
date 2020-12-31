import {User} from "../../model/User";

export class Department {
  name: string;
  id: string;
}

export class DepartmentAssignment {
  userId: string;
  departmentId: string;
}
