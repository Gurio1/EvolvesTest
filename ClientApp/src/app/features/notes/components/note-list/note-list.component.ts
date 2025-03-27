import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Note } from '../../models/note';
import { NotesService } from '../../services/notes.service';
import { NoteItemComponent } from '../note-item/note-item.component';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-note-list',
  standalone: true,
  imports: [NgFor, NoteItemComponent, RouterLink],
  templateUrl: './note-list.component.html',
  styleUrl: './note-list.component.css',
})
export class NoteListComponent implements OnInit {
  notes: Note[] = [];

  constructor(private notesService: NotesService) {}

  ngOnInit() {
    this.loadNotes();
  }

  loadNotes() {
    this.notesService.getAll().subscribe((notes) => {
      this.notes = notes;
    });
  }

  deleteNote(id: string) {
    this.notesService.delete(id).subscribe(() => {
      this.loadNotes();
    });
  }
}
