# Project môn học Thiết Kế Xây Dựng Hệ thống
## Nhóm thực hiện:
- Phạm Tiến Nam
- Nguyễn Huy Thành
- Lê Đức Thanh
- Phạm Ngọc Toàn
- Nguyễn Công Sỹ
- Đỗ Khắc Chung
## Cấu trúc thư mục:
- Web API: sử dụng Web API để tạo REST API
- Client:
    - Dashboard: client trang quản trị
    - Home: client trang chủ người dùng
## Cách chạy:
- Chạy API: Open solution trong thư mục WebAPI với Visual Studio, F5 để chạy API
- Chạy Client: 
    - CD vào thư mục /client
    - CD vào /dashboard hoặc /home
    - Chạy ng serve --port=xxxx -o (xxxx là cổng port). Nên config xxxx để tránh trùng port giữa 2 client và các process khác trong môi trường lập trình.