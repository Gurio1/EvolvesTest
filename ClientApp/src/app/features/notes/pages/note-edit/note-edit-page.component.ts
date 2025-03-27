import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Note } from '../../models/note';
import { NotesService } from '../../services/notes.service';
import { NoteFormComponent } from '../../components/note-form/note-form.component';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-note-edit',
  standalone: true,
  imports: [NoteFormComponent, NgIf],
  templateUrl: './note-edit-page.component.html',
  styleUrl: './note-edit-page.component.css',
})
export class NoteEditComponent implements OnInit {
  note?: Note;
  currentDate: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private notesService: NotesService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.notesService.getById(id).subscribe((note) => {
        this.note = note;
      });
    }
  }

  updateNote(noteData: Omit<Note, 'id'>) {
    if (this.note?.id) {
      this.notesService.updateNote(this.note.id, noteData).subscribe(() => {
        this.router.navigate(['/notes']);
      });
    }
  }
}
