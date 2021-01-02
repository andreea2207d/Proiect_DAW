import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ViewTeamsComponent} from "./teams/view-teams/view-teams.component";
import {EditTeamComponent} from "./teams/edit-team/edit-team.component";
import {CreateTeamComponent} from "./teams/create-team/create-team.component";
import {TeamService} from "./teams/team.service";
import {CreateProjectComponent} from "./projects/create-project/create-project.component";
import {EditProjectComponent} from "./projects/edit-project/edit-project.component";
import {ViewProjectsComponent} from "./projects/view-projects/view-projects.component";
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import {ProjectService} from "./projects/project.service";
import {AssignProjectComponent} from "./projects/assign-project/assign-project.component";
import {AssignTeamComponent} from "./teams/assign-team/assign-team.component";


@NgModule({
  declarations: [ViewTeamsComponent, EditTeamComponent, CreateTeamComponent, CreateProjectComponent, EditProjectComponent, ViewProjectsComponent, AssignProjectComponent, AssignTeamComponent],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  providers: [TeamService, ProjectService],
  exports: [ViewTeamsComponent, EditTeamComponent, CreateTeamComponent, CreateProjectComponent, EditProjectComponent, ViewProjectsComponent],
})
export class EngagementModule { }
