import React, { useContext, useEffect, useState } from 'react';
import { useObserver } from 'mobx-react'


import Dashboard from "../components/Dashboard";
import { Row, Col, Button } from 'reactstrap';
import LayoutContext from "../contexts/layout.context";
import Layout from '../interfaces/layout.interface'



const Configuration = (props: any) => {
    const store: any = useContext(LayoutContext);
    const [layout, setLayout] = useState([]);

    useEffect(() => {
        store.getLayout().then((data: any) => {
            setLayout(data)
        })
    }, [])

    const saveLayout = () => {
        store.saveLayout(layout)
    }

    const addWidget = () => {
        const color = "#" + ("000000" + Math.floor(Math.random() * 16777215).toString(16)).slice(-6);
        let max_y = -1;

        for (let item of layout) {
            if ((item as Layout).y > max_y) {
                max_y = (item as Layout).y;
            }
        }

        setLayout([...layout, {
            i: color,
            x: 0,
            y: max_y,
            w: 1,
            h: 1
        }]);
    }

    const deleteItem = (color: string) => {
        setLayout(layout.filter((item: Layout) => item.i != color))
    }

    const onLayoutChange = (l: any) => {
        setLayout(l);
    };

    return useObserver(() => {
        return (
            <React.Fragment>
                <Row style={{ borderBottom: '1px solid #aaa' }}>
                    <Col lg="12" md="12" style={{ display: 'flex', justifyContent: 'flex-end', paddingBottom: '4px' }}>
                        {layout.length > 0 ? <Button onClick={saveLayout} title={'Serialize layout to DB'}>Save</Button> : null}
                        <Button onClick={addWidget} title={'Add to dashboard'} style={{ marginLeft: '5px' }}>Add Widget</Button>
                    </Col>
                </Row>
                <Row>
                    <Col lg="12" md="12">
                        <Dashboard
                            layout={layout.map((item: Layout) => {
                                return { ...item }
                            })}
                            cols={12}
                            mode="edit"
                            onDelete={deleteItem}
                            preventCollision={true}
                            onLayoutChange={onLayoutChange}
                        />
                    </Col>
                </Row>
            </React.Fragment>
        )
    });

}
export default Configuration;

