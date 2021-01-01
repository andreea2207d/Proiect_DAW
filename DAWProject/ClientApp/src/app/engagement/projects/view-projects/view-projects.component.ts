import { Component, OnInit } from '@angular/core';
import {Project} from "../../models/Project";
import {ProjectService} from "../project.service";

@Component({
  selector: 'app-view-projects',
  templateUrl: './view-projects.component.html',
  styleUrls: ['./view-projects.component.css']
})
export class ViewProjectsComponent implements OnInit {
  projects: Array<Project>;
  selectedProject: Project;

  constructor(private projectsService: ProjectService) { }

  ngOnInit() {
    this.projectsService.getAllProjects().subscribe(projects => {
      this.projects = projects
    })
  }

  onDeleteProject(project: Project) {
    this.projectsService.deleteProject(project.id)
  }

  onEdit() {
    this.projectsService.getAllProjects().subscribe(projects => {
      this.projects = projects
    })
  }

  onSelectEdit(project: Project) {
    this.selectedProject = project
  }
}
