import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { Note } from '../../models/note';
import { NotesService } from '../../services/notes.service';

@Component({
  selector: 'app-note-detail',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './note-details-page.component.html',
  styleUrl: './note-details-page.component.css',
})
export class NoteDetailsComponent implements OnInit {
  note?: Note;

  constructor(
    private route: ActivatedRoute,
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
}
