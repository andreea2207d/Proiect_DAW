import {Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {Project} from "../../models/Project";
import {ProjectService} from "../project.service";

@Component({
  selector: 'app-edit-project',
  templateUrl: './edit-project.component.html',
  styleUrls: ['./edit-project.component.css']
})
export class EditProjectComponent implements OnInit {
  @Input() project: Project;
  // @ts-ignore
  @ViewChild('closeBtn') closeButton: ElementRef;
  @Output() onSelectEdit: EventEmitter<any> = new EventEmitter();
  @Output() onEdit: EventEmitter<any> = new EventEmitter();

  constructor(private projectService: ProjectService) { }

  ngOnInit() {
  }

  onSelectEditButtonClick() {
    this.onSelectEdit.emit()
  }

  onSaveChanges() {
    this.projectService.editProject(this.project).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onEdit.emit()
    });
  }
}
