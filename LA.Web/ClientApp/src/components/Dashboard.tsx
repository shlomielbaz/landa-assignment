import React from "react";
import RGL, { WidthProvider } from "react-grid-layout";
const ReactGridLayout = WidthProvider(RGL);

import Layout from '../interfaces/layout.interface';
import Widget from './Widget';

const Dashboard = (props: any) => {
  const generateDOM = () => {

    return props.layout && props.layout.map((item: Layout, idx: number) => <div key={item.i} className="x-widget">
      <Widget color={item.i} mode={props.mode || 'view'} onDelete={props.onDelete ? props.onDelete : () => { }}/>
    </div>) || (<div></div>);
  }

  
  return (
    <div>
      <ReactGridLayout
        rowHeight={30}
        cols={props.cols}
        layout={props.layout}
        compactType={null}
        onLayoutChange={props.onLayoutChange}
      >
        {generateDOM()}
      </ReactGridLayout>
    </div>
  );
}
export default Dashboard;