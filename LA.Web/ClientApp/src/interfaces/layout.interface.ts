
export default interface Layout {
    i: string;
    x: number;
    y: number;
    w: number;
    h: number;
    minW?: number;
    maxW?: number;
    minH?: number;
    maxH?: number;
    moved?: boolean;
    static?: boolean;
    isDraggable?: boolean;
    isResizable?: boolean;
    resizeHandles?: ("s" | "w" | "e" | "n" | "sw" | "nw" | "se" | "ne")[];
    isBounded?: boolean;
    color?: string;
}