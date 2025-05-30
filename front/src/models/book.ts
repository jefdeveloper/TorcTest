export type Book = {
  Title: string;
  FirstName: string;
  LastName: string;
  TotalCopies: number;
  CopiesInUse: number;
  Type?: string;
  Isbn?: string;
  Category?: string;
};