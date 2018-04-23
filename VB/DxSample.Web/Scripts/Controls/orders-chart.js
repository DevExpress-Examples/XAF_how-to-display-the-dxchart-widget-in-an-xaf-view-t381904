window.DxSample = window.DxSample || {};
window.DxSample.OrdersChart = {
    createWidgets: function (panel) {
        var $mainElement = $(panel.GetMainElement());
        var $chart = $mainElement.children('.dxsample-orderschart-chart');
        var $range = $mainElement.children('.dxsample-orderschart-range');
        $chart.dxChart({
            dataSource: {
                store: {
                    type: 'array',
                    data: panel.cpChartData
                }
            },
            commonSeriesSettings: {
                type: 'line'
            },
            seriesTemplate: { nameField: 'series' }
        });
        $range.dxRangeSelector({
            size: { height: 120 },
            margin: { left: 10 },
            scale: { minorTickCount: 1 },
            dataSource: {
                store: {
                    type: 'array',
                    data: panel.cpChartData
                }
            },
            chart: {
                seriesTemplate: { nameField: 'series' }
            },
            behavior: { callSelectedRangeChanged: 'onMoving' },
            onSelectedRangeChanged: function (e) {
                var chart = $chart.dxChart('instance');
                chart.zoomArgument(e.startValue, e.endValue);
            }
        });
    }
};
