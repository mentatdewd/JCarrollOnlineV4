export class HierarchyNodesModel<T> {
  Entity?: T;
  ChildNodes?: HierarchyNodesModel<T>[];
  Depth: number = 0;
  Parent?: T;
  ImageList?: string[];
}
