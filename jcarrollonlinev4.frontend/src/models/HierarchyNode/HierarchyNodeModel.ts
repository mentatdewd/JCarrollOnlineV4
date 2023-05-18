import { IModelBase } from "../IModelBase";

export interface HierarchyNodesModel<T> extends IModelBase {
  Entity?: T;
  ChildNodes: HierarchyNodesModel<T>[];
  Depth: number;
  Parent?: T;
  ImageList: string[];
}
