import { Component, OnInit } from '@angular/core';
import {Project} from "../../models/Project";
import {ProjectService} from "../project.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.css']
})
export class CreateProjectComponent implements OnInit {
  project: Project;

  constructor(private projectService: ProjectService, private router: Router) { }

  ngOnInit() {
    this.project = new Project()
  }

  onCreate() {
    this.projectService.createProject(this.project).subscribe(_ => {
      this.router.navigateByUrl('/view-projects')
    })
  }
}
