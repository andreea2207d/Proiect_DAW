import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {Team} from "../../models/Team";
import {TeamService} from "../team.service";

@Component({
  selector: 'app-edit-team',
  templateUrl: './edit-team.component.html',
  styleUrls: ['./edit-team.component.css']
})
export class EditTeamComponent implements OnInit {
  @Input() team: Team;
  // @ts-ignore
  @ViewChild('closeButton') closeButton: ElementRef;
  @Output() onSelectEdit: EventEmitter<any> = new EventEmitter();
  @Output() onEdit: EventEmitter<any> = new EventEmitter();

  constructor(private teamService: TeamService) { }

  ngOnInit() {
  }

  onSelectEditButtonClick() {
    this.onSelectEdit.emit()
  }

  onSaveChanges() {
    this.teamService.editTeam(this.team).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onEdit.emit()
    });
  }
}
