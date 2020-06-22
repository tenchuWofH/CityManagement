export interface Todo {
  id: number;
  content: string;
}

export interface Meta {
  totalCount: number;
}

export interface City {
  cityId: number;
  name: string;
  description: string;
  isCapital: boolean;
  pointsOfInterest: Array<PointOfInterest>;
}

export interface PointOfInterest {
  pointOfInterestId: number;
  name: string;
  description: string;
}
