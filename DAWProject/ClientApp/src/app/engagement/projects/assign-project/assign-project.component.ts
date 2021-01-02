import { Component, OnInit } from '@angular/core';

import {Router} from "@angular/router";
import {User} from "../../../model/User";
import {Project, ProjectAssignment} from "../../models/Project";
import {ProjectService} from "../project.service";
import {UserService} from "../../../organisation/user.service";

@Component({
  selector: 'app-assign-project',
  templateUrl: './assign-project.component.html',
  styleUrls: ['./assign-project.component.css']
})
export class AssignProjectComponent implements OnInit {

  users: Array<User>
  projects: Array<Project>
  selectedUser: User;
  selectedProject: Project;

  constructor(private userService: UserService, private projectService: ProjectService,
              private router: Router) { }

  ngOnInit() {
    this.userService.getAllUsers().subscribe(result => {
      this.users = result
    })
    this.projectService.getAllProjects().subscribe(result => {
      this.projects = result
    })
  }

  selectProject(project: Project) {
    this.selectedProject = project
  }

  selectUser(user: User) {
    this.selectedUser = user
  }

  assignUserToProject() {
    let projectAssignment = new ProjectAssignment()
    projectAssignment.userId = this.selectedUser.id
    projectAssignment.projectId = this.selectedProject.id
    console.log(projectAssignment)
    this.projectService.assignUser(projectAssignment).subscribe(_ => {
      this.router.navigateByUrl('view-projects').then()
    })
  }
}
