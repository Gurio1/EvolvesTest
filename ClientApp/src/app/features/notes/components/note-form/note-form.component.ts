import { Component, EventEmitter, Input, Output } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { Note } from '../../models/note';
import { CommonModule, Location } from '@angular/common';

@Component({
  selector: 'app-note-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './note-form.component.html',
  styleUrl: './note-form.component.css',
})
export class NoteFormComponent {
  @Input() note?: Note;
  @Output() formSubmit = new EventEmitter<Omit<Note, 'id'>>();

  noteForm: FormGroup;

  constructor(private fb: FormBuilder, private location: Location) {
    this.noteForm = this.fb.group({
      title: ['', Validators.required],
      content: ['', Validators.required],
    });
  }

  ngOnInit() {
    if (this.note) {
      this.noteForm.patchValue(this.note);
    }
  }

  onSubmit() {
    if (this.noteForm.valid) {
      this.formSubmit.emit(this.noteForm.value);
    }
  }

  goBack(): void {
    this.location.back();
  }
}
