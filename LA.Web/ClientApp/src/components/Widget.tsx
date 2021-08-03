import React, { Component } from 'react'
import './Widget.css'

const Widget = ({color, mode, onDelete, ...rest}) => {
    return (
        <div style={{ backgroundColor: color, height: 'inherit' }}>
            {
                mode === 'edit' ? <div className="x-delete" title="delete widget" onClick={() => {
                    if (onDelete instanceof Function) {
                        onDelete(color)
                    }
                }}>&times;</div> : null
            }
            <span className="x-widget-title"></span>
        </div>
    );
}



export default Widget;

