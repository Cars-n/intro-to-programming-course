import { http, delay, HttpResponse } from 'msw';
// msw is used for mocking network requests in web applications. It intercepts HTTP requests and provides predefined responses
// - `http`: Provides utilities for defining HTTP request handlers.
// - `delay`: Allows simulating network delay in responses.
// - `HttpResponse`: Used to construct HTTP responses with specific content and status codes.

const fakeItems = [
  {
    id: '99',
    completed: false,
    createdOn: '2025-02-11T20:58:47.300Z',
    description: 'Shovel Snow',
  },
  {
    id: '100',
    completed: true,
    createdOn: '2025-02-11T20:58:47.300Z',
    description: 'Make Tacos',
    completedOn: '2025-02-11T20:58:47.300Z',
  },
];

export const TodosHandler = [
  http.get('http://localhost:1337/todos', async () => {
    await delay();
    return HttpResponse.json(fakeItems);
  }),
];
