import {
  ChangeDetectionStrategy,
  Component,
  inject,
  resource,
  signal,
} from '@angular/core';
import { LinkDocsDisplayItemComponent } from './link-docs-display-item.component';
import { ResourceStore } from '../services/resource.store';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { map } from 'rxjs';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

import { FilterComponent } from './alt-filter-component';

@Component({
  selector: 'app-resources-list',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    LinkDocsDisplayItemComponent,
    RouterLink,
    FilterComponent,
    FilterComponent,
  ],
  template: `
    <app-resource-filter-2 />
    @if (store.filteredBy() !== null) {
      <p>Filtering By: {{ store.filteredBy() }}</p>
      <a
        [routerLink]="['.']"
        [queryParams]="{ filter: null }"
        class="btn btn-xs btn-secondary"
        >Clear Filter</a
      >
    }
    <div
      class="grid grid-cols-3  lg:grid-cols-4 md:grid-cols-3 sm:grid-cols-1 gap-4"
    >
      @for (link of store.filteredResourceList(); track link.id) {
        <app-link-docs-display-item [link]="link" />
      } @empty {
        <p>You don't have any resources! Add Some?</p>
      }
    </div>
  `,
  styles: ``,
})
export class ListComponent {
  store = inject(ResourceStore);
  activatedRoute = inject(ActivatedRoute);

  constructor() {
    this.activatedRoute.queryParams
      .pipe(
        takeUntilDestroyed(), // this will unsubscribe when this component is destroyed.
        map((params) => params['filter']), // { filter: 'angular'} => 'angular' | undefined
        map((f) => (f === undefined ? null : f)),
      )

      .subscribe((v) => this.store.setFilteredBy(v)); // YOU MUST Unsubscribe - you will get memory leaks.
  }

  // linksResource = resource({
  //   loader: () =>
  //     fetch('http://localhost:1338/resources').then((r) => r.json()),
  // });

  // links = signal<ResourceListItem[]>([
  //   {
  //     id: '1',
  //     title: 'Hypertheory Applied Angular Materials',
  //     description: 'Class Materials for Applied Angular',
  //     link: 'https://applied-angular.hypertheory.com',
  //     linkText: 'Hypertheory.com',
  //     tags: ['Angular', 'TypeScript', 'Training'],
  //   },
  //   {
  //     id: '2',
  //     title: 'NGRX',
  //     description: 'NGRX Family of Fine Angular Libraries',
  //     link: 'https://ngrx.io',
  //     linkText: 'NGRX.io',
  //     tags: ['Angular', 'TypeScript', 'Training', 'State', 'Signals', 'Redux'],
  //   },
  // ]);
}
