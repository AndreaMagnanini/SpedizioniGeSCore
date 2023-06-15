import React, {useEffect, useState} from 'react';
import ShipmentCard from "../components/ShipmentCard";
import {makeStyles, Typography} from "@material-ui/core";

const useStyles = makeStyles({
    title: {
        textAlign: "left",
        color: "#D41217",
        paddingTop: "10px"
    },
    pageRoot: {
        height:"100%",
        marginRight: "10px",
        marginLeft: "10px"
    }
});
function Home({year}) {
    const [shipments, setShipments] = useState([]);
    const classes = useStyles();
    useEffect(() => {
        fetch("api/shipment/" + year)
            .then(response => { return response.json() })
            .then(responseJson => {
                setShipments(responseJson);
            })
    }, []);
    return (
        <div className={classes.pageRoot}>
            <Typography variant="h4" className={classes.title}>
                Shipments
            </Typography>
            <div style={{ width: "100%", overflow: "auto", display: "flex" }}>
                {shipments.map((shipment) => (
                    <div style={{ height: "100%", display:"flex", marginTop: "25px", marginBottom:"30px", marginRight:"16px", marginLeft:"16px" }}>
                        <ShipmentCard shipment={shipment}></ShipmentCard>
                    </div>
                ))}
            </div>
        </div>
    );
}


export default Home;