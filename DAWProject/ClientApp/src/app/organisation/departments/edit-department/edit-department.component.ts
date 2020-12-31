import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Department} from "../../models/Department";
import {DepartmentsService} from "../departments.service";

@Component({
  selector: 'app-edit-department',
  templateUrl: './edit-department.component.html',
  styleUrls: ['./edit-department.component.css']
})
export class EditDepartmentComponent implements OnInit {
  @Input() department: Department;
  // @ts-ignore
  @ViewChild('closeBtn') closeButton: ElementRef;
  @Output() onSelectEdit: EventEmitter<any> = new EventEmitter();
  @Output() onEdit: EventEmitter<any> = new EventEmitter();

  constructor(private departmentService: DepartmentsService) { }

  ngOnInit() {
  }

  onSelectEditButtonClick() {
    this.onSelectEdit.emit()
  }

  onSaveChanges() {
    this.departmentService.editDepartment(this.department).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onEdit.emit()
    });
  }
}
