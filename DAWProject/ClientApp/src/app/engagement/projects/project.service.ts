import { Injectable } from '@angular/core';
import {BaseService} from "../../organisation/BaseService";
import {Project, ProjectAssignment} from "../models/Project";

@Injectable({
  providedIn: 'root'
})
export class ProjectService extends BaseService{

  getAllProjects() {
    return this.http.get<Array<Project>>(`${this.baseUrl}api/projects`)
  }

  createProject(project: Project) {
    return this.http.post(`${this.baseUrl}api/projects`, project)
  }

  editProject(project: Project) {
    return this.http.put(`${this.baseUrl}api/projects`, project)
  }

  deleteProject(projectId: string) {
    return this.http.delete(`${this.baseUrl}api/projects/${projectId}`)
  }

  assignUser(projectAssignment: ProjectAssignment) {
    return this.http.post(`${this.baseUrl}api/projects/assign/user`, projectAssignment)
  }
}
