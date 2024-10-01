package matcha.project.be.entity;

import jakarta.persistence.*;
import lombok.AccessLevel;
import lombok.Data;
import lombok.experimental.FieldDefaults;
import org.hibernate.annotations.CreationTimestamp;
import org.hibernate.annotations.UpdateTimestamp;

import java.time.LocalDateTime;

@Entity
@Table(name = "items")
@Data
@FieldDefaults(level = AccessLevel.PRIVATE)
public class ItemEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    Long id;

    @Column(nullable = false)
    String name;

    @Column(nullable = false)
    String brand;

    @Column(nullable = false)
    Double price;

    @Column(name = "image_url")
    String imageUrl;

    @Column(nullable = false, name = "category_id")
    Long categoryId;

    @Column(nullable = false, name = "amount_sold")
    Long amountSold;

    @CreationTimestamp
    @Column(nullable = false, updatable = false, name = "created_at")
    LocalDateTime createdAt;

    @UpdateTimestamp
    @Column(nullable = false, name = "updated_at")
    LocalDateTime updatedAt;
}
